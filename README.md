# BloggingApp

A backend soultion for a simple blogging platform that uses custom REST API for all requests using .NET Core (C#) and Entity framework for working with the database.

## Getting Started

BloggingScript.sc is for creating database tables.

SeedScript.sc is for seeding the data into the database, please run this script before build.

BloggingApp.bak is the database backup in case you wanna install it like that.

### Prerequisites

You will need:

Microsoft SQL Server Management Studio 2019.

Visual Studio 2019.

## Running the tests

* For getting the blog post by it's slug, you should run:
```
GET /api/post/:slug
```

* For getting a list of blog posts you should run:
```
GET /api/posts
```
there is also an optional filter by which you can search blogposts - tag. If you want to do that you should run:
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

**Note:** Notice that single posts are called by api/post, and multiple posts are called by api/posts. You can use **Swagger** to test all of these calls.




### Additional functionalities

When the user is creating the blog post, the tag list for that post is optional. When the user enters the values, if it's not existant in the database, it will add it then. If user nothing, this will be skipped.

For creating slugs, there is a custom made generator. If there are two same slugs, there will be added an index number on the end of the slug.

Example:

```
augmented-reality-ios-application-3
```

### Other

The relationship between BlogPost and TagList is a many-to-many relationship, which is why there is a third class called BlogsTags that connects them into that relationship.


