# Holiday Search 🔎

This repo provides functionality for a basic holiday search. I decided to use clean architecture over minimal APIs mainly due to separation of concerns and maintainability, especially since it’s a realistic project and I wanted my code to mirror that. I’ve spent approximately 4 hours from start to finish and have noted some areas of both things to be added and improvements (if had more time):

* Fix unit tests - although they run I have commented out a few areas that need fixing (with TODOs)
* More unit tests
* Handle DateTime types (currently just strings for simplicity and time constraints)

Also the following (in no particular order):

* Authenticate requests via controller
* Improve validators
* Include UI (preference would've been Angular but open to any) with tests i.e. Cypress
* Include Infrastructure project i.e. to read data from SQL DB rather than hardcoded JSON or to include external services if data is coming from elsewhere
* Setup Azure pipelines and to ensure all tests (frontend and backend) tests run as well as code linting
* Dockerise app
* Update this README with more detail on how to run the app (frontend, backend, docker etc.)
* Perhaps to utilise Postman for API testing
* Improve search functionality itself
