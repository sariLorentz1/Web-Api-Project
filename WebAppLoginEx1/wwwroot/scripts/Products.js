
var products;
var categoriesChecked=[];
var orderList = JSON.parse(localStorage.getItem("cart"))||[];
const pageLoad = async () => {

    products = await getAllProducts();
    categories = await getAllCategories();
    var count = 0;
    console.log(localStorage.getItem("cart"))
    if (localStorage.getItem("cart") != null) {
        (JSON.parse(localStorage.getItem("cart"))).map(p => (count += parseInt(p.quantity)));
        document.getElementById("ItemsCountText").innerText = count;
        console.log(count);
    }
    renderProducts(products);
    renderCategories(categories);
}

const renderProducts = async (products) => {
   
    products.map((product) => {
        const temp = document.getElementById("temp-card");
        const clone = temp.content.cloneNode(true);
        clone.querySelector("img").src = `../images/Ice/${product.img}.jpg`
        clone.querySelector("h1").innerText = product.name;
        clone.querySelector(".price").innerText = `${product.price} $`;
        clone.querySelector(".description").innerText = product.description;
        clone.querySelector("button").addEventListener("click", () => addToCart(product));
        document.getElementById("PoductList").appendChild(clone);
    })

}

const renderCategories = async (categories) => {

    categories.map((category) => {
        const temp = document.getElementById("temp-category");
        const clone = temp.content.cloneNode(true);
        clone.querySelector(".OptionName").innerText = category.name;

        clone.querySelector(".Count").innerText = products.filter(p => p.categoryName == category.name).length;
        clone.querySelector('.opt').id = category.id;
        clone.querySelector(".opt").addEventListener('change', (e) => {
            filterProducts(e.target.id);
        })
        document.getElementById("categoryList").appendChild(clone);
    })
}



const getAllProducts = async () => {
    const response = await fetch("https://localhost:44390/api/products", {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    return response.ok ? await response.json() : [];
}

const filterProducts = async (id) => {

    categoriesChecked = Array.from(document.getElementsByClassName('opt')).filter(category => category.checked).map(category => category.id)
    const categoriesUrl = categoriesChecked.length > 0 ? `&categoryId=${categoriesChecked.join("&categoryId=")}` : '';
    const name = document.getElementById("nameSearch").value;
    console.log("name " + name);
    const minPrice = document.getElementById("minPrice").value;
    console.log("minPrice " + minPrice);
    const maxPrice = document.getElementById("maxPrice").value;
    console.log("maxPrice " + maxPrice);
    const response = await fetch(`https://localhost:44390/api/products?name=${name}&minPrice=${minPrice}&maxPrice=${maxPrice} ${categoriesUrl}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })

    if (response.ok) {
        products = await response.json();
        console.log(products)
        document.getElementById("PoductList").innerHTML = "";
        renderProducts(products);
    }
} 


const getAllCategories = async () => {
    const response = await fetch("https://localhost:44390/api/categories", {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    return response.ok ? await response.json() : [];


}


const addToCart = (product) => {
    var x = orderList.length;
    product.quantity = product.quantity ? product.quantity :1;
    orderList.map(p => p.id == product.id ? p.quantity += 1 : x--);
    if (x == 0) {
        orderList.push(product)
    }
    console.log(orderList);
    
    document.getElementById("ItemsCountText").innerText = parseInt(document.getElementById("ItemsCountText").innerText)+1;
    var cart = JSON.stringify(orderList);

    localStorage.setItem("cart", cart );
}

document.addEventListener("load", pageLoad());