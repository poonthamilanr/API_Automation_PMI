Feature: Application Api Service Automation

This feature covers the Cert Application API Automation
Background:
	Given Generate access token for application service

#Experience Module for Application service
@Qa @Can @Prod @local @timeout:30 @debug @AppApi
Scenario: Verify experience for a given application
	When Get experience details
	Then Verify experience details

@Qa @Can @Prod @local @timeout:30 @debug @AppApi
Scenario: Verify experience by experience id
	When Get experience details
	Then Verify experience details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience hours for a given application
	When Get experience details
	Then Verify experience details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience hours by experience hours id
    When Get experience hours details
    Then Verify experience hours details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience projects for a given application
	When Get experience details
	Then Verify experience details

#Expirence id and Experience Project Id are changing dynamicaly
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience projects by experience project id
    When Get experience project details
    Then Verify experience project details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience summery for a given application
	When Get experience summery for a given application
	Then Verify experience summery for a given application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience summery by experience summery id
    When Get experience summery details
    Then Verify experience summery details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify open experience summery for a given application
	When Get open experience summery for a given application
	Then Verify open experience summery for a given application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience can be added and deleted for an application
    When Add experience
    Then Verify experience
	 And Add other experience
    Then Verify other experience
	 And Delete all experience
	When Get experience details
	Then Verify experience deleted

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience project can be added and deleted for an experience
    When Add experience project
    Then Verify experience project
	 And Add other experience project
    Then Verify other experience project
	 And Delete all experience project
	When Get experience project details
	Then Verify experience project deleted

#ExperienceSummaryQuestions get Calls 
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience summary questions for application id and experience summary id
	When Get experience summary questions for application id and experience summary id
	Then Verify experience summary questions for application id and experience summary id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience summary questions by id
	When Get experience summary questions by providing id
	Then Verify experience summary questions by id

#ExperienceSummaryAnswers get Calls 
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience summary answers for application id and experience summary id
	When Get experience summary answers for application id and experience summary id
	Then Verify experience summary answers for application id and experience summary id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience summary answers by question id
	When Get experience summary answers by question id
	Then Verify experience summary answers by question id

#Group Exams get Calls 
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify group exam details by id
	When Get group exam details by id
	Then Verify group exam details by id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify group exam details by identifier
	When Get groups exam details by identifier
	Then Verify groups exam details by identifier


#Application Review Get call Scenarios
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application review by rule id
	When Get application review rule by rule id
	Then Verify application review rule by id

@Qa @Can @Prod @local @timeout:30 @debug @AppApi
Scenario: Verify application review rules
	When Get application review rules
	Then Verify application review rules details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application review rule types
	When Get application review rule types
	Then Verify application review rule types

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application review by application id
	When Get application review by application id
	Then Verify that application reviewed by all application review rules
	#For this scenarion the application status shoulb be in submitted status

#Application Review Post call Scenarios
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application review rule against a specified application in preview mode
    When Provide application id and rule id
    Then Verify applied application review rule against a specified application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application review against a specified application
    When Provide application id of specified application
    Then Verify application review against a specified application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application review against a specified application in preview mode
    When Provide application id of specified application for preview
    Then Verify application review against a specified application in preview mode

#Application module get calls
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application details by application id
	When Get application details by id
	Then Verify application details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify academic details by application id
	When Get academic details by application id
	Then Verify academic details by application id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify all valid transitions for a given application
	When Get and Verify the all valid transitions for a given application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify name on certificate by application ID
	When Get name on certificate by application ID
	Then Verify name on certificate by application ID

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify experience requirenment for application ID by work type
	When Get experience requirenment for pmp application by worktype
	Then Verify experience requirenment for pmp application by worktype

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify education requirenment for application ID
	When Get education requirenment for pmp application
	Then Verify education requirenment for pmp application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify requirenment status for an application ID
	When Get requirenment status for an application
	Then Verify requirenment status for an application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify valid transition events for an application by ID
	When Get valid transition event details for an application by ID
	Then Verify valid transition event details for an application by ID

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify assignment score for an application by ID
	When Get and verify assignment score for an application by ID

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify Experience summary comment for an application by ID
	When Get Experience summary comment for an application by ID
	Then Verify Experience summary comment details for an application by ID

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application details by person ID
	When Get application details by person ID
	Then Verify application details response by person ID

@Qa @Can @local @timeout:30 @debug @AppApi @DS
Scenario: Verify active application for a given person and credential type and create if none exists
	When Get active application for a given person and credential type and create if none exists
	Then Verify active application details for a given person and credential type and create if none exists

@Qa @Can @local @timeout:30 @debug @AppApi @DS
Scenario: Verify that newly created application for an user by person ID
	When Get create application for a given person and credential type
	Then Verify created application details for a given person
	#This scenario is only verifying that user is eligible to create an application

@Qa @Can @local @timeout:30 @debug @AppApi @DS
Scenario: Verify open application details for an user by person ID and credential
	When Get open application details for a given person and credential type
	Then Verify open application details for a given person

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify payment information for open application for an user by person ID and credential
	When Get payment information for open application for a given person and credential type
	Then Verify payment information for open application details for a given person

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify all values for an application for a given person
	When Get application details for a given person and credential type
	Then Verify all values in an application for a given person

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application details for a given person for mypmi
	When Get application details for a given person for mypmi
	Then Verify all application details for a given person for mypmi

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application details using specific user access token
	When Get an application details with a specific user access token
	Then Verify the application details with a specific user access token

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify that user can eligible to apply for an application for specific user access token
	When Get the status os user whether thay are eligible or not to apply with a specific user access token
	Then Verify response details of specific user that eligible or not to apply for an application
	#This scenario is only verifying that user is eligible to create an application

@Qa @Can @local @timeout:30 @debug @AppApi @DS
Scenario: Verify user can create an application for specific user access token
	When Get active application for a credential type and create if none exists for a specific user access token
	Then Verify created application details of specific user that eligible or not to apply for an application

@Qa @Can @local @timeout:30 @debug @AppApi @DS
Scenario: Verify if the user eligible to create application for a credential type for specific user access token
	When Get an user eligible to create application for a credential type
	Then Verify application creation eligibility details for a specific user access token

@Qa @Can @local @timeout:30 @debug @AppApi @DS
Scenario: Verify opened application details for a given credential type using specific user access token
	When Get opened application details for a given credential type using specific user access token
	Then Verify the details opened application details for a given credential type using specific user access token

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify payment information for open application for a specific user access token
	When Get payment information for open application for a specific user access token
	Then Verify payment information for open application details for a specific user access token

@Qa @Can @local @timeout:30 @debug @AppApi @DS
Scenario: Verify that new application is added for a given person and credential type
	When Submit new application for a given person and credential type
	Then Verify added new application details for a given person and credential type

@DS @local @timeout:30 @debug @Qa @Can @AppApi
Scenario: Verify reopen event for given application
    When Submit the reopen event for given application
    Then Verify the response of reopen event for given application

@DS @local @timeout:30 @debug @Qa @Can @AppApi
Scenario: Verify close expire event for given application
    When Submit the close expire event for given application
    Then Verify the response of close expire event for given application

@DS @local @timeout:30 @debug @Qa @Can @AppApi
Scenario: Verify close event for given application
    When Submit the close event for given application
    Then Verify the response of close event for given application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify that group number is set for myPMI
    When Submit the group number for given application
    Then Verify group number is set for given application

@DS @local @timeout:30 @debug @AppApi
Scenario: Verify approve event for a given application
    When Submit approve event for a given application
    Then Verify application approved event details for a given application

@DS @local @timeout:30 @debug @AppApi
Scenario: Verify audit event for a given application
    When Submit audit event for a given application
    Then Verify application audit event details for a given application

#
#Scenario: Verify audit document received event for a given application
#	When Submit and verify audit document received event for a given application followed by audit event

@DS @local @timeout:30 @debug @AppApi
Scenario: Verify audit fail event for a given application
	When Submit and verify audit fail event for a given application followed by audit event

@DS @local @timeout:30 @debug @AppApi
Scenario: Verify audit grant extension event for a given application
	When Submit and verify audit grant extension event for a given application followed by audit event

@DS @local @timeout:30 @debug @AppApi
Scenario: Verify audit reset event for a given application
	When Submit and verify audit reset event for a given application followed by audit event

#
#Scenario: Verify audit reset docs not received event for a given application
#	When Submit and verify audit reset docs not received event for a given application followed by audit event

@DS @local @timeout:30 @debug @Qa @Can @AppApi
Scenario: Verify extend eligibility event for a given application
	When Submit extend eligibility event for a given application
	Then Verify extended eligibility details
	
@DS @local @timeout:30 @debug @Qa @Can @AppApi
Scenario: Verify submit payment event for a given application
	When Submit payment event for a given application 'uri'
	Then Verify submitted payment details

#@DS @local @timeout:30 @debug @Qa @Can @AppApi
#Scenario: Verify approve exam accommodation for an application and exam id
	#Modification is required once data scaffolding user is ready for special accomm pending
	#When Request special accommodation for an exam
	#Then Verify special accommodation requested details
	 #And Approve special accommodation request for a given application and exam id
	#Then Verify that special accommodation are approved

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify active exam record for given application
	When Get active exam record for given application
	Then Verify active exam record for given application

@DS @local @timeout:30 @debug @AppApi
Scenario: Verify application rejection by given application id
	When Reject an application for a given application id
	Then Verify rejected application detail


#Configuration Get Calls For Application Service
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify application requirement settings by credentials
	When Get application requirement settings by credentials
	Then Verify application requirement settings by credentials

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify applications business rule settings
	When Get applications business rule settings
	Then Verify applications business rule settings

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify certifications general settings
	When Get certifications general settings
	Then Verify certifications general settings

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify applications enterprise settings
	When Get applications enterprise settings
	Then Verify applications enterprise settings

#Exam modules of Application service
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify exams by application id
	When Get exams by application id
	Then Verify exams by application id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify exams by exam id
	When Get exams by exam id
	Then Verify exams by exam id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify exams identification address
	When Get exams identification address
	Then Verify exams identification address

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify exams identification name
	When Get exams identification name
	Then Verify exams identification name

#Audit get Calls 
@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify list of audit documents by application id
	When Get a list of audit documents by application id
	Then Verify a list of audit documents by application id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify aduit document details by audit id
	When Get audit details by id for an application
	Then Verify audit details for an application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify that one application review rule for an application
	When Submit an application review rule for an application
	Then Verify the response of executed appreview rulr for that application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify list of audit documents by application id using specific user access token
	When Get a list of audit documents by application id using specific user access token
	Then Verify a list of audit documents by application id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify audit summary by certification type using specific user access token
	When Get audit summary by certification type using specific user access token
	Then Verify audit summary by certification type

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify blob storage document can be able to download
    When  Download blob storage document by Audit document id
    Then  Verify blob storage document details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify multiple docusign docuemnts can be able to download
    When  Download multiple docusign docuemnts for given application id
    Then  Verify docusign documents details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify create a docusign envelope manually
    When  Submit create a docusign envelope manually
    Then  Verify created docusign envelope details

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify send audit reference request
    When Provide and send audit refernce request
    Then Verify audit reference request sent

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify that audit packet expiration date updated
    When Update audit expiration date for given application
    Then Verify the response for audit expiration date updated for given application

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify blob storage document upload
    When Update the blob document for an application by audiy document Id
    Then Verify that blob document is updated for an application

#Education scenarios
@Qa @Can @Prod @local @timeout:30 @debug @AppApi
Scenario: Verify education for a given application Id
	When Get eductaion for a given application id
	Then Verify reponse of education for aplication id

@Qa @Can @Prod @local @timeout:30 @debug @AppApi
Scenario: Verify education by Id
	When Get eductaion by id
	Then Verify reponse for education by id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify education history that can be applied the given application id
	When Get education history that can be applied the given application id
	Then Verify response for education history that can be applied the given application id

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify education can be added and deleted for an application
    When Add education
    Then Verify education
	When Education details deleted
	And  Get eductaion by id
	Then Education should be deleted

@Qa @Can @local @timeout:30 @debug @AppApi
Scenario: Verify panel reviewer assignments and status
    When  Provide Panel reviewer person id details
    Then  Verify response for given panel reviewer