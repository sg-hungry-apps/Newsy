# Newsy

Endava tech assignment

Backend API that will support a news-related web and mobile application.
The apps are supposed to be used by readers and by authors who publish and edit articles.

API endpoints:
- Users controller
    - Register
    - Login
- Article controller
    - Get article
    - Get articles by author
    - Search articles
    - Save article
    - Edit article
    - Delete article
 
Web/mobile pages I had in mind that the frontend will have were the following:
- Home page with todays news
- Detailed page of a single news
- Register page
- Login page
- Search news page
- Users page listing their articles and the ability to add/edit/delete articles

Technical notes:
- I didn't use a database because of the simplicity of the task, showing my skills and experience on more important parts of the code seemed like a better time investment.
- Used a simple test data class that should be the same each start of the API.
- Added a couple of tests but there is a lot more to add.
- Using Swagger and it's UI for testing along the way.
- Using JWT authetication

TODOs for the future:
- Add database
- Adding more tests, for multiple parts of the project
- Adding comments and reviews for news article
- Better validation for requests, especially around sensitive information
- Saving sensitive data in a more secure way
- Introduce an admin role and the admin dashboard page on the application
- Add logging
- Middleware for defending against XSS or SQL attacks
- Middleware for checking request and response headers
- Add options for 2FA authentication
- Newsletter via email or some updates
- Add option for retrieving/resetting password
- Add controller (with approriate APIs) and page for editing user data
- Add option to add files/photos etc and save it
- Consider Markdown files or some other approach giving the user more freedom to present the article
- Add Dto in the name of DTOs
- Various TODOs in the code for small changes
