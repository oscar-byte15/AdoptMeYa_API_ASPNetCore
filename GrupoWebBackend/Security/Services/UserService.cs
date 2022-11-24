using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using GrupoWebBackend.Security.Authorization.Handlers.Interfaces;
using GrupoWebBackend.Security.Domain.Entities;
using GrupoWebBackend.Security.Domain.Repositories;
using GrupoWebBackend.Security.Domain.Services;
using GrupoWebBackend.Security.Domain.Services.Communication;
using GrupoWebBackend.Shared.Domain.Repositories;
using GrupoWebBackend.Shared.Exceptions;
using BCryptNet = BCrypt.Net.BCrypt;

namespace GrupoWebBackend.Security.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IMapper _mapper;
        
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtHandler jwtHandler, IMapper mapper)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _jwtHandler = jwtHandler;
            _mapper = mapper;
        }

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
        {

            var user = await _userRepository.FindByUsernameAsync(request.UserNick);
            
            // Validate

            if (user == null || !BCryptNet.Verify(request.Pass, user.PasswordHash))
                throw new AppException("Username or password is incorrect.");
            
            // Authentication is successful

            var response = _mapper.Map<AuthenticateResponse>(user);

            response.Token = _jwtHandler.GenerateToken(user);

            return response;

        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await _userRepository.ListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.FindByIdAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found.");
            return user;
        }

        public async Task RegisterAsync(RegisterRequest request)
        {
            // Validate
            if (_userRepository.ExistsByUsername(request.UserNick))
                throw new AppException($"Username {request.UserNick} is already taken.");
            
            // Map request to User model
            var user = _mapper.Map<User>(request);
            
            // Hash Password
            user.PasswordHash = BCryptNet.HashPassword(request.Pass);
            
            // Save User
            try
            {
                await _userRepository.AddAsync(user);
                await _unitOfWork.CompleteAsync();
            }   
            catch(Exception e)
            {
                throw new AppException($"An error occurred while saving the user: {e.Message}");
            }
        }

        public async Task UpdateAsync(int id, UpdateRequest request)
        {
            var user = GetById(id);
            
            // Validate
            if (_userRepository.ExistsByUsername(request.UserNick))
                throw new AppException($"Username {request.UserNick} is already taken.");
            
            // If Password is not null, then Hash it
            if (!string.IsNullOrEmpty(request.Pass))
                user.PasswordHash = BCryptNet.HashPassword(request.Pass);
            
            // Map to User model
            _mapper.Map(request, user);
            try
            {
                _userRepository.Update(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while updating the user: {e.Message}");  
            }
        }

        public async Task DeleteAsync(int id)
        {
            var user = GetById(id);
            
            try
            {
                _userRepository.Remove(user);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception e)
            {
                throw new AppException($"An error occurred while deleting the user: {e.Message}");  
            }
        }

        // Internal Helpers
        private User GetById(int id)
        {
            var user = _userRepository.FindById(id);
            if (user == null) throw new KeyNotFoundException("User not found.");
            return user;
        }


        public async Task<UserResponse> UpdateUser(User user, int id)
        {
            var existingUser = await _userRepository.FindByIdAsync(id);
            if (existingUser == null)
                return new UserResponse("Pet not found");
            existingUser.Type = user.Type;
            existingUser.UserNick = user.UserNick;
            existingUser.Name = user.Name;
            existingUser.Ruc = user.Ruc;
            existingUser.Dni = user.Dni;
            existingUser.Phone = user.Phone;
            existingUser.Email = user.Email;
            existingUser.LastName = user.LastName;
            existingUser.UrlToImageBackground = user.UrlToImageBackground;
            existingUser.UrlToImageProfile = user.UrlToImageProfile;
            existingUser.DistrictId = user.DistrictId;

            try
            {
                _userRepository.UpdateUser(existingUser);
                await _unitOfWork.CompleteAsync();
                return new UserResponse(existingUser);
            }
            catch (Exception e)
            {
                return new UserResponse($"An error occurred while saving Category: {e.Message}");
            }
        }
        
    }
}