
function drawProduct(p) {
            console.log("p" + p + p.name)
            const temp = document.querySelector("#temp-row");
            const clone = temp.content.cloneNode(true);
            clone.querySelector("tr").id = "id" + p.id;
            console.log(p.img)
            console.log(p)
            clone.querySelector(".imageColumn img").src = `../images/Ice/${p.img}.jpg`;
            clone.querySelector(".descriptionColumn h3").innerText = p.name;
            console.log(p.quantity)
            clone.querySelector(".price").innerText = p.price * p.quantity;
            let itemNumber = clone.querySelector('.amountColumn h3')
            itemNumber.textContent = p.quantity
            let more = clone.querySelector('.amountColumn #more')
            more.addEventListener('click', () => { changeAmount(p.id, '+', p.price) })

            let less = clone.querySelector('.amountColumn #less')
            less.addEventListener('click', () => { changeAmount(p.id, '-', p.price) })
            clone.querySelector(".expandoHeight").onclick = () => { removeItem(p.id) };
            document.querySelector("tbody").appendChild(clone);
}

window.onload = () => {
    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    console.log(cart);
    countProducts = 0;
    sumPrice = 0;
    cart.map((p) => {
        drawProduct(p)
    }
    )
    setHead(cart);

}

function setHead(products) {
    let count = 0, sum = 0;
    products.forEach(p => { count += p.quantity; sum += (p.quantity * p.price) })
    document.getElementById('itemCount').textContent = count;
    document.getElementById('totalAmount').textContent = sum;
}


function drawProducts(products) {
    let items = document.querySelector('#items tbody')
    items.innerHTML = ''
    if (products.length > 0)
        products.forEach((p) =>
        {
            drawProduct(p) 
        })
}

function changeAmount(productId, operation,price) {
    console.log("productId" + productId)
    let products = JSON.parse(localStorage.getItem('cart'))
    let amount;
    products.forEach(p => { if (p.id == productId) { operation == '-' ? p.quantity -= 1 : p.quantity += 1; amount = p.quantity } })
    console.log("amount" + amount)
    if (amount == 0) {
        removeItem(productId)
        return
    }
    console.log("products" + products)
    setHead(products)
    drawProducts(products)
    localStorage.setItem('cart', JSON.stringify(products))
}

const drawOrderProducts = () => {

}

const removeItem = (id) => {
    console.log("id"+id)
    var cart = JSON.parse(localStorage.getItem("cart")) || [];
    const updatedCart = cart.filter(p => p.id != id);
    console.log(updatedCart);
    localStorage.setItem("cart", JSON.stringify(updatedCart));
    const element = document.querySelector("tbody").querySelector(`#id${id}`);
    document.querySelector("#itemCount").innerText = updatedCart.length;
    var currentSum = 0;
    updatedCart.map((p) => { currentSum += p.price})

    document.querySelector("#totalAmount").innerText = currentSum;
    console.log("e"+element);
    document.querySelector("tbody").removeChild(element);

}

const placeOrder = async () => {
    const cart = JSON.parse(localStorage.getItem("cart")) || [];
    const orderDate = (new Date()).toISOString();
    
    if (cart.length == 0) return;

    const orderSum = parseInt( document.querySelector("#totalAmount").innerText);
    if (sessionStorage.getItem("userInfo") == null) return;
    console.log("lll")
    const user = JSON.parse(sessionStorage.getItem("userInfo"))
    const id=user.id;
    const orderItems = cart.map(p => { return { productId: p.id, quantity: p.quantity } });
    console.log({ orderSum })
    console.log({ orderDate })
    console.log({ id })
    console.log({ orderItems })
    const order = JSON.stringify({ sum: orderSum, date: orderDate, userId: id, orderItems: orderItems });
  



    const response = await fetch("https://localhost:44390/api/orders", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: order
    })
    console.log(response.status);
    if (response.ok) {
        localStorage.setItem("cart", null);
        const r = await response.json();
        console.log(r);
        console.log(r.id);

        alert(`הזמנתך בוצעה בהצלחה, הזמנה מס:${r.id}`);
        window.location.href = '/pages/home.html';
    } 

}
