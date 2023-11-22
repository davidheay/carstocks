# Car Stock Api

The CarStocks API is a ASP.NET Core-based solution designed to facilitate the management of car stocks for various dealers.

### Features:

1. Authentication and Authorization: 

   Implements secure authentication mechanisms like JWT (JSON Web Tokens) to ensure that each dealer can access and manage only their respective car stocks. Authentication ensures that the API endpoints are accessible only to authorized users.

2. Car Management Operations:

   1. Add/Remove Car: Allows dealers to add new cars to their inventory or remove existing cars.
   2. List Cars and Stock Levels: Provides endpoints to list cars available in the inventory along with their respective stock levels, model, etc...
   3. Update Car: Enables dealers to update the stock levels of existing cars in their inventory and all its information.
   4. Search Car By Make and Model: Allows searching for cars based on their make and model.

3. Data Management:

   Utilizes an in-memory data structure to simulate the database

4. Swagger Integration:

   Incorporates Swagger UI to offer an interactive and user-friendly documentation interface for the API.

5. Dockerization:

   Allowing for easy deployment and scalability by encapsulating the API within a Docker container.

### Steps to run


1. Pull docker image:

   ```
   docker pull davidheay/car-stock
   ```

2. Run docker image:

   ```
   docker run -d -p 8080:80 davidheay/car-stock
   ```

3. Navigate to [swagger view](http://localhost:8080/swagger/index.html)

### Steps to use


1. Ask for  Jwt token:

    ```
    curl -X 'POST' 
    'http://localhost:8080/api/Auth/generateToken'
    -H 'accept: */*'
    -H 'Content-Type: application/json'
    -d '{
    "id": [DEALER ID],
    "name": "[DEALER NAME]"
    }'
   ```
   *You can use ids: 1238979213, 24424314, 3213152*

2. Use endpoints:

   ```
    curl -X 'POST/GET' \
    'http://localhost:8080/api/[DEALER ID]/cars' \
    -H 'accept: text/plain' \
    -H 'Authorization: Bearer [TOKEN]' \
    -H 'Content-Type: application/json' \
    -d '{}'
   ```

### Things to do

* **key**: Protect the jwt key and get it from environment variables.
* **passwords**: User and Password for jwt.
* **tests**: Add unit test and integrations tests.
* **coverage**: Add a minimum coverage percentage to build it.
* **sql**: Implement a SqlServer database.
* **compose**: Docker compose for database.
