Feature: PetServiceTest
As a Developer
I wan to add new Pet through API
So that it is available when wanting to make publications.
	Background: 
		Given The Endpoint https://localhost:5001/api/v1/Pets is available
		And A user is already stored
		  | Id | Type | UserNick | Pass     | Ruc      | Dni      | Phone     | Email             | Name      | LastName | DistrictId |
		  | 1000  | VET  | string    | string | A12345rf | 70258688 | 946401234 | frank@outlook.com | Francisco | Voularte  | 0          |
@pet-adding
Scenario: Add Pet
	When A Post Request is sent
	  | Type | Name | Attention | Race    | Age | IsAdopted | UserId | PublicationId |
	  | Can  | Lolo | Yes       | Pitbull | 2   | false     | 1      | 1             |
	Then A Response With Status 200 is received
	
Scenario: Add Pet with empty data
	When A Post Request is sent
	  | Type | Name | Attention | Race    | Age | IsAdopted | UserId | PublicationId |
	  | Can  | Lolo | Yes       |        | 2   | false     | 3   | 1             |
	Then A Response With Status 400 is received
