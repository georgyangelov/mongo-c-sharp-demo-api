Calendar Application for MongoDB Driver Demo
============================================

How to use
----------

Edit the api_base_url in index.html.

Endpoints required:

- GET    /tasks                     - get all tasks (currently not used)
- GET    /tasks/{id}                - get specific task (currently not used)
- GET    /tasks/for_date/2014-10-25 - get all tasks for the given date
- POST   /tasks                     - Create a new task
- PUT    /tasks                     - Update (replace) an existing task
- DELETE /tasks/{id}                - Delete a task

A task has:

- title     - string
- text      - string
- priority  - integer in [0, 1, 2, 3]
- completed - boolean (should default to false)
- date      - datetime - the date it is for

Make sure the server can parse the dates and ids without issues.

Also, if hosting the front-end and server on different HTTP ports make sure you enable cross-origin requests with the following headers:

    Access-Control-Allow-Origin: *
    Access-Control-Allow-Methods: POST,GET,PUT,DELETE
    Access-Control-Allow-Headers: Accept, Origin, Content-type
  
Enjoy
-----
