Feature: AddServiceTestsSteps
As a developer
I want to publish adds through API
So that I can get buyers
    Background: 
        Given the endpoint https://localhost:5001/api/v1/Advertisements is available.

	
    @advertisement2-adding
    Scenario: Add An Advertisement
        When A Post Request of Advertisement is sent
          | DateTime         | Title | Description     | Discount | UrlToImage                                                           | Promoted | UserId |
          | 29/09/2021 16:20 | hola  | add description | 10       | https://www.lasamarillasdezipaquira.com/oc-content/uploads/1/352.jpg | true     | 1      | 
        Then An Advertisement response with status 400 is received
	
    Scenario: Add An Advertisement with empty data
        When A Post Request of Advertisement is sent
          | DateTime         | Title          | Description     | Discount | UrlToImage                                                           | Promoted | UserId |
          | 29/09/2021 16:20 |                | add description | 10       | https://www.lasamarillasdezipaquira.com/oc-content/uploads/1/352.jpg | true     | 1      |
        Then An Advertisement response with status 400 is received
	
    Scenario: Delete An Advertisement 
        Given the endpoint https://localhost:5001/api/v1/Advertisements/1 is available.
        When an a deleting request is sent
        Then a response with status 200 is received

    Scenario: Update An Advertisement with correct id and body
        Given the endpoint https://localhost:5001/api/v1/Advertisements/1 is available.
        When An update Advertising request is sent    
          | DateTime         | Title | Description     | Discount | UrlToImage                                                           | Promoted | UserId |
          | 29/09/2021 16:20 | hola  | add description | 10       | https://www.lasamarillasdezipaquira.com/oc-content/uploads/1/352.jpg | true     | 1      | 
        Then a response with status 200 is received