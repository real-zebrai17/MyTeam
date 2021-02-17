Feature: User Login

Background: 
	Given A Newly Configured System

Scenario: User unsucessfully logs when user not found
	 When User Logs in with User User and Password
 	 Then Unauthorized
	 And Login user Is Null

Scenario: User unsucessfully logs in with password
	Given User User Exists
	  And Password for User is set to Password
	 When User Logs in with User User and Invalid
 	 Then Unauthorized
	 And Login user Is Null

Scenario: User sucessfully logs in with password
	Given User User Exists
	  And Password for User is set to Password
	 When User Logs in with User User and Password
 	 Then Success
	 And Login user set to User