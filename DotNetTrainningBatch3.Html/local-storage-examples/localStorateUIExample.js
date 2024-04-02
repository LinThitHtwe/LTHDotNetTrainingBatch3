const localStorageName = "blogs";
let blogId = "";

function getAllBlogs() {
  $("#blogTable").html("");
  const blogs = getExistingBlog();
  let tableRow = "";

  blogs.forEach((blog, i) => {
    tableRow += `
   <tr>
        <th scope="row">${i + 1}</th>
        <td>${blog.title}</td>
        <td>${blog.author}</td>
        <td>
            <button type="button" class="btn btn-secondary" onclick="getBlogById('${
              blog.id
            }')">Edit</button>
            <button type="button" class="btn btn-danger" onclick="deleteBlog('${
              blog.id
            }')">Delete</button>
    </td>
    </tr>
   
   `;
  });
  $("#blogTable").html(tableRow);
}

function getBlogById(id) {
  const blogs = getExistingBlog();
  const blog = blogs.find((blog) => blog.id === id);
  if (!blog) {
    alert("No Data Found");
    return;
  }

  $("#title").val(blog.title);
  $("#author").val(blog.author);

  blogId = blog.id;
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
    alert("No Data Found. Wrong Id");
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
  const deletePermission = confirm("Do you want to delete?");
  if (!deletePermission) return;
  const blogs = getExistingBlog();
  const deletedArray = blogs.filter((blog) => blog.id != id);
  blogs.length == deletedArray.length
    ? alert("No data got deleted. Wrong Id")
    : setLocalStorage(deletedArray);

  $("#title").val("");
  $("#author").val("");

  $("#title").focus();

  getAllBlogs();
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

$("#save").click(function () {
  const title = $("#title").val();
  const author = $("#author").val();
  if (!blogId) {
    createBlog(title, author);
    alert("Successfully Saved");
  } else {
    updateBlog(blogId, title, author);
    alert("Successfully Updated");
    blogId = "";
  }

  $("#title").val("");
  $("#author").val("");

  $("#title").focus();

  getAllBlogs();
});

getAllBlogs();
