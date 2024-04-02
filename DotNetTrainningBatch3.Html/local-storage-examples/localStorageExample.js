const localStorageName = "blogs";

function run() {
  //getAllBlogs();
  //getBlogById("696ea66e-d7e0-4ba9-b96c-5554b723a35f");
  //getBlogById("696ea66e-d7e0-4ba9-b96c-");
  //createBlog("Test", "Testing");
  //deleteBlog("696ea66e-d7e0-4ba9-b96c-5554b723a35f");
  updateBlog("d1277003-ec77-4ce8-b8b0-024b0d21a731", "Updated", "Updateddd");
}

function getAllBlogs() {
  const blogs = getExistingBlog();
  blogs.forEach((blog) => {
    console.log(blog.id, blog.title, blog.author);
  });
}

function getBlogById(id) {
  const blogs = getExistingBlog();
  const blog = blogs.find((blog) => blog.id === id);
  blog
    ? console.log(blog.id, blog.title, blog.author)
    : console.log("No blog found");
}

function createBlog(title, author) {
  const blogList = getExistingBlog();
  const blog = { id: uuidv4(), title, author };
  blogList.push(blog);
  setLocalStorage(blogList);
}

function updateBlog(id, title, author) {
  const blogs = getExistingBlog();
  const index = blogs.findIndex((blog) => blog.id == id);
  if (index < 0) {
    console.log("Wrong Id. No Data Found");
    return;
  }
  blogs[index] = {
    id,
    title,
    author,
  };
  setLocalStorage(blogs);
}

function deleteBlog(id) {
  const blogs = getExistingBlog();
  const deletedArray = blogs.filter((blog) => blog.id != id);
  blogs.length == deletedArray.length
    ? console.log("No data got deleted. Wrong Id")
    : setLocalStorage(deletedArray);
}

function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (c / 4)))
    ).toString(16)
  );
}

function getExistingBlog() {
  let blogList = [];
  const existingBlog = localStorage.getItem(localStorageName);
  if (existingBlog) blogList = JSON.parse(existingBlog);
  return blogList;
}

function setLocalStorage(blogs) {
  const jsonString = JSON.stringify(blogs);
  localStorage.setItem(localStorageName, jsonString);
}

run();
