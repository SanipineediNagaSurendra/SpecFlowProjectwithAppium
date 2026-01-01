Feature: SettingsApp

A short summary of the feature

@tag1
Scenario: validating settings app
	Given user scroll and click on "More settings" element
	When user scroll and click on "Accessibility"
	And user click on "Accessibility shortcut" element
	And user disable the Accessibility shortcut checkbox button

@tag2
Scenario: validating Smart clickbutton
    Given user click on "Smart Mirroring" element
	When user click on "Search for supported devices"
	Then  user verify the "Local media mirroring"
	When user click on "Refresh" button

	
