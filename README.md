# PetStoreApiFramework
Api testing framework created by using C#, RestSharp and NUnit.

Tests are configurable from config.json file where you can add enviroment specific data.

Framework are based on objects and dto's and it's deserialization.

Endpoints are stored in specific Endpoints classes categorized by swagger categories.
Requests methods are also categorized and stored in different classes.
Tests are extended by Test Base class which loads configuration based on current enviroment.


Framework uses Allure reports which have attached all requests/response history:
![image](https://user-images.githubusercontent.com/46795587/184531262-c9b72ea9-3dcd-4881-8f21-5c4903540365.png)
![image](https://user-images.githubusercontent.com/46795587/184531286-cee4fa26-4e67-4572-9e90-d0b5922827ea.png)

To generate and open allure report use:
1. Run tests with any test runner. Generated Allure reports will appear in directory you configured with allureConfig.json

2. Generate the report the following CMD command:

allure generate "allure-results-directory" --clean

3. Open the report through the following CMD command:

allure open "allure-report-directory"
