# Goal

The goal of the project is create a full-stack application using a raspberry pi to host a dotnet WebApi written in C#, that serves a simple html page (user interface)
that will send requests to the WebApi to make queries to a mariadb SQL database that is also hosted on the raspberry pi, and sends the results of those queries 
back to the user interface where they can be rendered and viewed as tables by the user.

## Install mariadb and create a database with tables and data on Raspberrypi

First install mariadb on the raspberry pi using: ``` sudo apt install mariadb-server ``` , login to the mariadb and run ``` CREATE DATABASE stevesdoors ```. 
Then define an SQL file `Steves.sql` in order to define database table schemas, create tables, and insert some dummy data 
into the tables. Use mysql to run that file with the mysql command to initialize the database, tables, and populate those tables with data 
``` mysql -u hazel -p stevesdoors < Steves.sql```. 

## Install .NET framework on Raspberrypi
Next, install the .NET framework from Microsoft onto the raspberry pi. I followed this guide to accomplish this: https://behroozbc.hashnode.dev/install-net-on-a-raspberry-pi .

Then use ``` dotnet new web -n StevesApi ``` command to create a new dotnet webapi project on the
raspberry pi. 

##Install MySqlConnector and Newtonsoft packages
In order to speed up the development process, install the MySqlConnecter dotnet package:
``` dotnet add package MySqlConnector ```
to connect the C# WebApi to a mariaDB database that was created on the Pi. This package will also help us make SQL queries.

I also installed the Newtonsoft JSON dotnet packages:
```
dotnet add package Newtonsoft.Json
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 8.0.0
``` 
so that its possible to easily serialize C# objects (the query results as DataTable objects) and send them back to the client-side in an Http response.

## Create a DatabaseHandler object to handle database connection and queries
Using C# create a `DatabaseHandler.cs` object that will create a connection to the mariadb database and make queries.
It uses two methods to make queries: ``` DatabaseHandler.ExecuteQueryAsync ``` to handle queries that return data 
and ``` DatabaseHandler.ExecuteNonQuery ``` to handle queries that do not return data (INSERT, UPDATE, DELETE). 

## Create ApiController to handle http Get and Post requests from front-end
Then I creates a Controller `StevesApiController.cs` to handle the api requests coming from the front-end. Most of these endpoints are HttpGet endpoints:
```
    [HttpGet("customer")]
    public async Task<IActionResult> GetCustomerAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM Customer");
        var response = new { Customers = dt };
        return Ok(response);
    }

    [HttpGet("order")]
    public async Task<IActionResult> GetOrderAsync()
    {
        var dt = await db.ExecuteQueryAsync("SELECT * FROM `Order`");
        var response = new { Orders = dt };
        return Ok(response);
    }

    Below are what the coresponding requests look like on the front-end

    async function customer() 
    {
        const response = await fetch( piAddress + "/api/customer" );
        const data = await response.json();
        console.log(data);
        createTable(data.customers);
    }
    
    async function order()
    {
        const response = await fetch( piAddress + "/api/order" );
        const data = await response.json();
        console.log(data);
        createTable(data.orders);
    }

``` 
The HttpGet simply serve to make a ``` SELECT * FROM table ``` query to the database using a `DatabaseHandler.cs` object that we created to execute queries. 
We call the ``` DatabaseHandler.ExecutQueryAsync() ``` method to make queries to our databse. The results of those 
queries are placed in DataTable objects then sent back to the front-end in an HTTP response (made serializable by the Newtonsoft Package) so they can be rendered 
for viewing.

There is also an HttpPost endpoint that will handle Post requests with data to insert into a `Products` table using the DatabaseHandler object.
```
    [HttpPost("product")]

    // handles asynchronous operation: fetches data, then returns an appropriate result 
    public async Task<IActionResult> AddProductAsync(Product product) //Use the Product class to extract data values in the request to use on line 36
    {
        // Inserts new row into Products table
        // Use the values of the product value argument and interpolate the values in the query string
        var affectedRows = await db.ExecuteNonQueryAsync($"INSERT INTO Product (ProductName, Description, Material, Size, Color, Price, StockQuantity) VALUES('{product.Productname}', '{product.Description}', '{product.Material}', '{product.Size}', '{product.Color}', {product.Price}, {product.StockQuantity})");
        return Ok(affectedRows);

    }

    Below is the coresponding front-end code that makes the post request
    $("#productform").submit( async function(event){
        // Prevent default form submit behavior
        event.preventDefault();
        // Create form data object and populate with form input values
        var formData = { 
            productname : $("#productname").val(),
            description : $("#description").val(),
            material : $("#material").val(),
            size : $("#size").val(),
            color : $("#color").val(),
            price : $("#price").val(),
            stockquantity : $("#stockquantity").val()
        }
    
        // Make a POST request to web API wiith the form data in the request body
        const response = await fetch ( piAddress + "/api/product", {
            method : "POST", 
            headers : {
                "Content-Type" : "application/json"
            },
            body : JSON.stringify(formData)
        })
        
        // Console log how many rows were affected IF successful 
        const data = await response.json();
        console.log(data);
    })
```
## Create HomeController to serve the user interface
The `HomeController.cs` serves a simple `index.cshtml` page that will serve as a front-end that a user can utilize to make requests for data from the 
dotnet webapi. It contains several buttons that are connected to functions that will make asynchronous calls to the dotnet webapi using the built-in 
javascript `fetch` function, and jQuery to render the data from the webapi response into a <table> then update the UI with that newly generated table.

The front-end also has a form that will take the data in that form, put it in a request object, and make a post request to the HttpPost endpoint method 
which is setup to make an INSERT SQL statement to create a new row in the `Product` table in the database.

## Start the dotnet WebApi
Once all of this is setup, start the WebApi and listen for requests using ``` dotnet run ```. 

## Make a request for the user interface
Then from a client browser, navigate to the IP address of the pi and the port that dotnet is listening for requests on to get the user interface from the raspberry pi. 

## Summary
In summary, when the user device navigates to the IP address of the raspberry pi on the same network, it will serve an index.html as a user interface. 
The buttons on that user interface are programmed to make asynchronous requests to the dotnet web API running on the raspberry pi requesting data from 
the database. The WebApi uses a mariadb connection to make queries to a mariadb database hosted on the Raspberry pi, and return the results back to the 
client in an http response. The client will then use jQuery to render the data in the response into an html table. The UI has a form that will submit data 
to the HttpPost endpoint in the WebApi using an Http post request. The endpoint will use the mariadb connection to insert that data into a table in the mariadb database. 
