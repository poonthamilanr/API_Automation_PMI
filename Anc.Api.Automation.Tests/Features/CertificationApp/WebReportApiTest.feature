Feature: WebReport Api Service Automation

This feature covers the WebReport API Automation
Background: 
	Given Generate access token for Webreport service

@Qa @Can @local @timeout:30 @debug @WebReports
Scenario: Verify candidate audit report
	When  Get audit report details by providing application id and experience id 
	Then  Verify the generated audit report

@Qa @Can @local @timeout:30 @debug @WebReports 
Scenario: Verify candidate cover letter
	When  Get cover letter report details
	Then  Verify the generated cover letter

@Qa @Can @local @timeout:30 @debug @WebReports
Scenario: Verify candidate eco report
	When  Get eco report details by providing person id and exam id 
	Then  Verify the generated eco report

@Qa @Can @local @timeout:30 @debug @WebReports 
Scenario: Verify packing list
	When  Get packing list details
	Then  Verify the generated packing list details

@Qa @Can @local @timeout:30 @debug @WebReports
Scenario: Verify certified user credential certificate
	When  Get certificate for a certified user by person id and certification type
	Then  Verify the certificate details

@Qa @Can @local @timeout:30 @debug @WebReports
Scenario: Verify candidate cycle summary report
	When  Get cycle summary report by providing person id 
	Then  Verify the generated cycle summary report

@Qa @Can @local @timeout:30 @debug @WebReports
Scenario: Verify certified user transcript details
	When  Get transcript by passing person id 
	Then  Verify the transcript details

@Qa @Can @local @timeout:30 @debug @WebReports 
Scenario: Verify candidate application report
	When  Get application report based on person id and application id
	Then  Verify the application report

@Qa @Can @local @timeout:30 @debug @WebReports 
Scenario: Verify candidate batch details
	When  Get candidate batch details 
	Then  Verify the batch details



