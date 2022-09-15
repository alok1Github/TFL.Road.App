# This app has been built on .net 6, needs visual studio 2022.


# Steps to build & run the project .
  1. Download the repo and open it in vs2022
  2. Go to the solution property and select multiple startup projects 
  3. Change TFL.API and TFL.ClientApp to Start from None , then click Apply and click OK.
  4. Rebuild the entire solution.  
  5. Go to the appsettings.json inside the TFL.API project and inside that file find section named as "RoadConfigRequest" and give your values for Key and AppId.
  6. Press Start button to run the project (wait for both the project to run )  
  
  # For running Unit test 
    Go to Visual studio menu click on Test -> Run All Tests . 
    This should open the window with tests for both API and client and run all the tests . 

 # Other Notes 
   I put Small "To Do's" where I think If more time spend i would love to do it .
