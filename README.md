# AzureFunction.UserCRUD

![](https://img.shields.io/badge/azure%20functions-v3-brightgreen) 
[![Build status](https://dev.azure.com/JiadongChen/AzureFunction.UserCRUD/_apis/build/status/chenjd-function-crud%20-%20CI)](https://dev.azure.com/JiadongChen/AzureFunction.UserCRUD/_build/latest?definitionId=6)
![](https://vsrm.dev.azure.com/JiadongChen/_apis/public/Release/badge/6b9d908e-6c86-401e-afd7-f515ef7684bb/3/3)

A sample CRUD project demonstrates the process of Azure Function using EntityFramework Core to operate Azure Sql database.
![](https://miro.medium.com/max/1400/1*L81ZubK3g0g9bwuDg9KdcA.png)

## Create a User data

Create a new user data in the sql database.

    POST /api/create

### Parameters
| Name  | Type | Description |
| ------------- | ------------- | ------------- |
| `name`  | `string`  | **Required.** The user's name.|
| `password`  | `string`  | **Required.** The user's password.|

### Example for creating a user

    {
        "name": "lydia",
        "password": "password"
    }
### Response
    user is created, the id is xxx
    
## Get a User data

Get a user data from the sql database.

    GET /api/read/:userid

### Response

    {
      "id": "fc78c67e-cf6a-4335-ae9c-7ac8459dbc2e",
      "name": "lydia",
      "password": "password"
    }
    
## Get a Users List

Get a users list from the sql database.
    
    GET /api/list
    
### Response

    [
        {
            "id": "f560927e-4564-456f-aceb-35aa32cf7c08",
            "name": "susan",
            "password": "password"
        },
        ...
    ]

## Update a User data

Update a existing user data in the sql database.

    PUT /api/update/:userid
    

### Parameters
| Name  | Type | Description |
| ------------- | ------------- | ------------- |
| `name`  | `string`  | **Required.** The user's name.|
| `password`  | `string`  | **Required.** The user's password.|


## Delete a User data
Delete a user data in the database.

    GET /api/delete/:userid
    


## Blog Post

[Using VS Code To Build An Azure Function And SQL Database App With .Net Core On Azure Cloud](https://levelup.gitconnected.com/using-vs-code-to-build-an-azure-function-and-sql-database-app-with-net-core-on-azure-cloud-9ab42febf9fa) 
