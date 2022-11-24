Feature: AdoptionsRequestsServiceTests
As a Developer
I want to add new Adoption Requests through API
So that it is available when the user make a adoption requests
	Background: 
		Given The Endpoint https://localhost:5001/api/v1/AdoptionsRequests is available
		And A User is already stored for AdoptionsRequests
		  | Id | Type | UserNick | Pass     | Ruc      | Dni      | Phone     | Email             | Name      | LastName | DistrictId |
		  | 1  | VET  | Frank    | Password | A12345rf | 70258688 | 946401234 | frank@outlook.com | Francisco | Voularte | 1          |
@adoptionsrequests-adding
Scenario: A AdoptionsRequests is sent 
	When A adoption request is sent
	| Message | Status  | UserIdFrom | UserId | PublicationId |
	| hello   | pending | 2           |1        |1            |
	Then A Response with Status 200 is received
Scenario: Add Adoption Request with empty data
	When A post adoption request is sent
	  | Message | Status  |
	  | hello   |  	      |
	Then AAdoptionRequests With Status 400 is received
Scenario: Add Adoption Request with same data
	When A post adoption request is sent
	  | Message | Status  | UserIdFrom | UserId | PublicationId |
	  | hello   | pending | 2          |1       |1              |
	Then AAdoptionRequests With Status 200 is received
	
  Scenario: Delete a adoptions request dont available
        When An a delete request of adoptions requests is sent   
          | Message | Status  | UserIdFrom | UserId | PublicationId |
          | hello   | pending | 2          |2       |18              |
        Then a response with status 400 is received
    
       Scenario: Database update its information when there is a new candidate for adopting
	  Given the endpoint https://localhost:5001/api/v1/AdoptionsRequests/1 is available
	       And A User is already stored for AdoptionsRequests
	         | Id | Type | UserNick | Pass     | Ruc      | Dni      | Phone     | Email             | Name      | LastName | DistrictId |
	         | 2  | client  | an    | Password | A12345rf | 70258688 | 946401234 |ana@gmail.com | Ana | Araoz | 1          |
	  When An update  adoption request is sent    
	    | Message | Status  | UserIdFrom | UserId | PublicationId |
	    | hello   | pending | 2          |1       |1              |
	       Then a response with status 200 is received