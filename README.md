
<h1 align="center" style="font-weight: bold;">Rare Publishing 💻</h1>

<p align="center">
<a href="#tech">Technologies</a>
<a href="#started">Getting Started</a>
<a href="#routes">API Endpoints</a>
<a href="#colab">Collaborators</a>
</p>


<p align="center">A full-stack application that allows users to post their original written content, discover content from other users, follow their favorite content creators, and comment on posted content.

User's have full CRUD capabilities on their own content, so previously published content can be revised or removed by the original content creator.</p>


<p align="center">
<a href="https://github.com/ursapictura/Rare-FE">Check out the client-side repo!</a>
</p>

<h2 id="tech">💻 Technologies</h2>

- C#
- .NET
- pgAdmin
- Swagger
- GitHub
- Visual Studio

<h2 id="started">🚀 Getting started</h2>

TO run this server-side of this project, you will need to clone this repo and have access to Visual Studio, .NET, and pgAdmin.

<h3>Prerequisites</h3>

Here you list all prerequisites necessary for running your project. For example:

- [Visual Studio](https://visualstudio.microsoft.com//)
- [.NET](https://dotnet.microsoft.com/en-us/)
- [pgAdmin](https://www.pgadmin.org/)

The client-side portion of this application isn't necessary if you plan to build your own front-end. If you choose to use the frontend we've designed, [you'll need to clone it from here.](https://github.com/ursapictura/Rare-FE)

<h3>Cloning</h3>

How to clone your project

```bash
git clone your-project-url-in-github
```

<h3>Starting</h3>

How to start your project

```bash
cd project-name

npm install

npm i --save react-select

dotnet new gitignore

dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 6.0

dotnet add package Microsoft.EntityFrameworkCore.Design --version 6.0

dotnet user-secrets init

dotnet user-secrets set "RareDbConnectionString" "Host=localhost;Port=5432;Username=postgres;Password=<your_postgresql_password>;Database=Rare-BE"
```

<h2 id="routes">📍 API Endpoints</h2>

Here you can list the main routes of your API, and what are their expected request bodies.
​
| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /checkuser/{uid}</kbd>     | checks for user authentication using Firebase
| <kbd>GET /users/{userId}</kbd>     | retrieves specific user's information
| <kbd>POST /users</kbd>     | creates a new user
| <kbd>GET posts</kbd>     | retrieves all posts
| <kbd>GET /posts/{postId}</kbd>     | retrieves specific post
| <kbd>POST /posts</kbd>     | creates a new post
| <kbd>PUT /posts/{postId}</kbd>     | change information in specific post
| <kbd>DELETE /posts/{postId}</kbd>     | removes a specific post from the database
| <kbd>GET /posts/search</kbd>     | search for posts by title, author, content, and category
| <kbd>GET /posts/categories/{categoryId}</kbd>     | retrieves all posts from the specific category
| <kbd>GET /categories</kbd>     | retrieves list of post categories
| <kbd>GET /tags</kbd>     | retrieves list of post tags
| <kbd>POST /tags</kbd>     | creates a new tag
| <kbd>POST /posts/{postId}/add-tag/{tagId}</kbd>     | adds a specific tag to a specific post
| <kbd>DELETE /posts/{postId}/remove-tag/{tagId}</kbd>     | removes a specific tag from a specific post
| <kbd>GET /subscription/{userId}</kbd>     | retrieves all of a user's active subscriptions and posts from those subscribed authors
| <kbd>GET /subscription/{userId}/{authorId}</kbd>     | allows a user to subscribe to an author
| <kbd>PATCH /subscription/{userId}/end/{authorId}</kbd>     | ends a user's subscription to an author
| <kbd>GET /subscription/{userId}/{authorId}</kbd>     | checks if a user is actively subscribed to an author
| <kbd>POST /comments</kbd>     | create a new comment on a specific post
| <kbd>DELETE /comments/{commentId}</kbd>     | allows a user to delete one of their comments from a specific post

<h2 id="colab">🤝 Collaborators</h2>

<p>Special thank you for all people that contributed to this project.</p>
<table>
<tr>

<td align="center">
<a href="https://github.com/ursapictura">
<img src="https://avatars.githubusercontent.com/u/104770521?v=4" width="100px;" alt="Haley Smith Profile Picture"/><br>
<sub>
<b>Haley Smith</b>
</sub>
</a>
</td>

<td align="center">
<a href="https://github.com/alexberka">
<img src="https://avatars.githubusercontent.com/u/148516337?v=4" width="100px;" alt="Alex Berka Profile Picture"/><br>
<sub>
<b>Alex Berka</b>
</sub>
</a>
</td>

<td align="center">
<a href="https://github.com/yarelismartin">
<img src="https://avatars.githubusercontent.com/u/153558948?v=4" width="100px;" alt="Yarelis Martin Profile Picture"/><br>
<sub>
<b>Yarelis Martin</b>
</sub>
</a>
</td>

<td align="center">
<a href="https://github.com/jessefrench">
<img src="https://avatars.githubusercontent.com/u/106822556?v=4" width="100px;" alt="Jesse French Profile Picture"/><br>
<sub>
<b>Jesse French</b>
</sub>
</a>
</td>

</tr>
</table>

<h3>📝 Helpful Documentation</h3>

[Client-Side UI for this project](https://github.com/ursapictura/Rare-FE)
