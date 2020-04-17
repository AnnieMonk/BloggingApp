# BloggingApp

A backend soultion for a simple blogging platform that uses custom REST API for all requests using .NET Core (C#) and Entity framework Core for working with the database where I used DATABASE FIRST principle.

## Getting Started

* BloggingScript.sc is for creating database tables.

* SeedScript.sc is for seeding the data into the database, please run this script before build.

* BloggingApp.bak is the database backup in case you wanna install it like that.


### Prerequisites

You will need:

Microsoft SQL Server Management Studio 2019 to run the scripts.

Visual Studio 2019 to run the application.

## Running the tests

* For getting the blog post by it's slug, you should run:
```
GET /api/post/:slug
```

* For getting a list of blog posts you should run:
```
GET /api/posts
```
This will reproduce a list of blog posts, and a post count value.

There is also an optional filter by which you can search blogposts - tag. If you want to do that you should run:
```
GET /api/post?=tagName
```

* For creating a blog post you should run:
```
POST /api/post
```
Required fields: title, description, body.

Optional fields: tagList as an array of strings.

* For updating a blog post by it's slug you should run:
```
PUT /api/posts/:slug
```
Optional fields: title, description, body

The slug also gets updated when the title is changed.

* For deleting a blog post, you should run:
```
DELETE /api/post/:slug
```

* To get all tags, you should run:
```
GET /api/tags
```

**Note:** Notice that single posts are called by api/post, and multiple posts are called by api/post**s**. You can use **Swagger** to test all of these calls.




### Additional functionalities

When user is creating the blog post, the tag list for that post is optional. When user enters tags, if they're not existant in the database, they will be added then. If user enters nothing, this will be skipped.

For creating slugs, there is a custom made generator. If there are two same slugs, an index number at the end of the slug will be added.

Example:

```
augmented-reality-ios-application-3
```

### About model

The relationship between BlogPost and TagList is a many-to-many relationship, which is why there is a third class called BlogsTags that connects them into that relationship.

![image](https://user-images.githubusercontent.com/41583631/79556261-1e05ad80-80a1-11ea-9f9e-810bf4b4cc05.png)

## Nuggets used

* Swagger
  - https://www.nuget.org/packages/Swashbuckle.AspNetCore/5.3.2?_src=template
  - https://www.nuget.org/packages/Swashbuckle.AspNetCore.Swagger/5.3.2?_src=template

* AutoMapper 
  - https://www.nuget.org/packages/AutoMapper/9.0.0?_src=template
  - https://www.nuget.org/packages/AutoMapper.Extensions.Microsoft.DependencyInjection/7.0.0?_src=template
  
* Entity Framework Core
  - https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/3.1.3?_src=template
  - https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design/3.1.3?_src=template
  - https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/3.1.3?_src=template
  - https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/3.1.3?_src=template

* Other:
  - https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/3.1.2?_src=template







