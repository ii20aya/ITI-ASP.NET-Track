const tabsContainer = document.getElementById('tabs-container');
const postsList = document.getElementById('posts-list');


fetch('https://jsonplaceholder.typicode.com/users')
    .then(response => response.json())
    .then(users => {
        users.forEach(user => {
            const btn = document.createElement('button');
            btn.innerText = user.username;
            btn.onclick = () => getPosts(user.id); 
            tabsContainer.appendChild(btn);
        });
    })
    .catch(error => console.error("Error fetching users:", error));




    

async function getPosts(userId) {
    postsList.innerHTML = "<li>Loading posts...</li>"; 
    try {
        const response = await fetch(`https://jsonplaceholder.typicode.com/posts?userId=${userId}`);
        const posts = await response.json();
        
        postsList.innerHTML = ""; 
        posts.forEach(post => {
            const li = document.createElement('li');
            li.innerText = post.title;
            postsList.appendChild(li);
        });
    } catch (error) {
        console.error("Error fetching posts:", error);
    }
}