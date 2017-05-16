Feature: AddComment
	I want to add a comment and make sure it gets submitted by the broker api

@mytag
Scenario: Add a comment
	Given a comment
	When the request is posted to the comments controller
	Then the new comment is available in the message broker via GetComment
