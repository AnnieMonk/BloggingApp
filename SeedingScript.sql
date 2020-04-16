use BloggingApp

INSERT INTO [dbo].[TagList]
VALUES ('iOS'),('AR'),('Gazza')

INSERT INTO [dbo].[BlogPost]
VALUES ('augmented-reality-ios-application', 'Augmented Reality iOS Application', 'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', 'The app is simple to use, and will help you decide on your best furniture fit.', GETDATE(), GETDATE()),
('augmented-reality-ios-application-2', 'Augmented Reality iOS Application 2', 'Rubicon Software Development and Gazzda furniture are proud to launch an augmented reality app.', 'The app is simple to use, and will help you decide on your best furniture fit.', GETDATE(), GETDATE())

INSERT INTO [dbo].[BlogsTags]
VALUES (1,1),(1,2),(2,1),(2,2),(2,3)