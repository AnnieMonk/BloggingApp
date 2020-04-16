CREATE DATABASE BloggingApp
GO

USE BloggingApp
GO

CREATE TABLE BlogPost(
BlogPostID int not null primary key identity(1,1),
Slug nvarchar(255) not null,
Title nvarchar(50) not null,
Description nvarchar(200) not null,
Body text not null,
CreatedAt datetime not null,
UpdatedAt datetime not null

);
CREATE TABLE TagList(
TagListID int not null primary key identity(1,1),
TagName nvarchar(50) not null


);

CREATE TABLE BlogsTags(
BlogsTagsID int not null primary key identity(1,1),
BlogPostID int not null,
TagListID int not null

);


alter table BlogsTags WITH CHECK ADD  CONSTRAINT [FK_BlogsTags_TagList] FOREIGN KEY ([TagListID]) REFERENCES [dbo].[TagList] ([TagListID])
alter table BlogsTags WITH CHECK ADD  CONSTRAINT [FK_BlogsTags_BlogPost] FOREIGN KEY ([BlogPostID]) REFERENCES [dbo].[BlogPost] ([BlogPostID])



