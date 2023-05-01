

const pageLoad = async () => {
    const products = await getAllProducts();
    const categories = await getAllCategories();
    //const product = products[0];
    //console.log(product);
    products.map((product) => {
        const temp = document.getElementById("temp-card");
        const clone = temp.content.cloneNode(true);
        //clone.querySelector("img").src = `../images/Ice/${product.img}.jpg`
        clone.querySelector("h1").innerText = product.name;
        clone.querySelector(".price").innerText = `${product.price} $`;
        clone.querySelector(".description").innerText = product.description;
        clone.querySelector("button").addEventListener("click", addToCart(product));
        document.getElementById("PoductList").appendChild(clone);
    })
    categories.map((category) => {
        const temp = document.getElementById("temp-category");
        const clone = temp.content.cloneNode(true);
        clone.querySelector(".OptionName").innerText = category.name;
        clone.querySelector(".Count").innerText = products.filter(p => p.category.name == category.name).length;
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

const filterProducts = async (categories, name, minPrice, maxPrice) => {
    const response = await fetch(`https://localhost:44390/api/products?name=${name}&minPrice=${minPrice}&maxPrice=${maxPrice}`, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json'
        }
    })
    return response.ok ? await response.json() : [];
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

}

document.addEventListener("load", pageLoad());