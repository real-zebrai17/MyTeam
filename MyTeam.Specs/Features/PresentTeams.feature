@Team Management
Feature: Present Teams

Background: 
	Given A Newly Configured System

Scenario: Present when not logged in
	 When I present teams
     Then Unauthorized

Scenario: Present when no teams present with admin user
	Given User User Exists
	  And User User is in Admin Role
	  And User User is Logged In
	 When I present teams 
	 Then no teams are presented
	  And The available actions contains Create
	  And Success

Scenario: Present when teams are present with logged in user
	Given The following Teams exist
		| name   |
		| Team A |
		| Team B |
		| Team C |
	  And User User Exists
	  And User User is Logged In
	 When I present teams 
	 Then teams are presented
		| name   | number of members |
		| Team A | 0                 |
		| Team B | 0                 |
		| Team C | 0                 |
	  And no actions available
	  And Success

Scenario: Present when no teams present when not logged in
	Given The following Teams exist
		| name   |
		| Team A |
		| Team B |
		| Team C |
	 When I present teams 
	 Then no teams are presented
	  And no actions available
	  And Unauthorized
	
