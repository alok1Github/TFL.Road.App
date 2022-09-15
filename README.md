# TThis app has been built on .net 6, needs visual studio 2022.
# This Solution named As TFL.App, has 5 project 
   # TFL.API - Statnd alon API can be consumed by any Client. 
   # TFL.API.Tests - respective Tests
   # TFL.ClientApp - it's a client for TFL.API (and it has the ability to configure clinet ,provide deffient model)   
   # TFL.ClientAppTests -respective Tests
   # TFL.Common - Its a common proejct

# Steps to build & run the project .
  # Download the repo and open it in vs2022
  # Go to the solution property and select multiple startup projects 
  # Change TFL.API and TFL.ClientApp to Start from None , then click Apply and click OK.
  # Rebuild the entire solution.  
  # Go to the appsettings.json inside the TFL.API project and inside that file find section named as "RoadConfigRequest" and give your values for Key and AppId.
  # Press Start button to run the project (wait for both the project to run )  
  
  # For running Unit test :
  #  Go to Visual studio menu click on Test -> Run All Tests . This should open the window with tests for both API and client and run all the tests . 

 # Other Notes :
 # I put Small "To Do's" where I think If more time spend i would love to do it .
