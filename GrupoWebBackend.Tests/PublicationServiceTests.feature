Feature: PublicationServiceTests
As a Developer
I wan to add a new Publication through API
So that it is available when wanting to see my publications.
    Background: 
        Given the endpoint https://localhost:5001/api/v1/publications is available
  #NOTA-SOLO FUNCIONA SI LA BASE DE DATOS TIENE LOS MISMOS DATOS DEL USER ID Y PET ID 
    @publication-adding
    Scenario: Post a publication 
        When A publication is sent
        | PetId | UserId | DateTime         | Comment                |
        | 1     | 4      | 29/09/2021 16:20 | This is a test comment |    
        Then a response with status 200 is received
      
    Scenario: Post a publication with incorrect json body
        When A publication is sent
          | petId | userId | dateTime         | conment                |
          | 1     | 1      | 29/09/2021 16:20 | This is a test comment |    
        Then a response with status 400 is received
    #NOTA-SOLO FUNCIONA SI LA BASE DE DATOS TIENE LOS MISMOS DATOS DEL USER ID Y PET ID Y PUBLICATION ID
    Scenario: Update a publication with correct id and body
        Given the endpoint https://localhost:5001/api/v1/publications/2 is available
        When An update  publication is sent    
          | PetId | UserId | DateTime     | Comment                        |                    
          | 2     | 4      | date updated | This is a test comment updated |    
        Then a response with status 200 is received  
         
    Scenario: Update a publication with wrong publication id
        Given the endpoint https://localhost:5001/api/v1/publications/1 is not available
        When An update  publication is sent    
         | PetId | UserId | DateTime         | Comment                        |                    
         | 2      | 0     | date updated     | This is a test comment updated |    
        Then a response with status 400 is received
        
  Scenario: Delete a publication
      Given the endpoint https://localhost:5001/api/v1/publications/2 is available
      When An a delete request is sent   
      Then a response with status 200 is received
      
  Scenario: Delete a publication go wrong
        Given the endpoint https://localhost:5001/api/v1/publications/1 is not available
        When An a delete request is sent   
        Then a response with status 400 is received
        
    Scenario: Get all current publications as a vet
        Given the endpoint https://localhost:5001/api/v1/Users/3/publications is available now
        When A get publications by user request is sent   
        Then a response with status 200 is received