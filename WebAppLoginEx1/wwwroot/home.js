
async function LogIn() {
    console.log("login");
    const email = document.getElementById("email").value;
    const password = document.getElementById("password").value;
    const user = JSON.stringify({ password: password, email: email });
    const response = await fetch(
        '/api/users', {
        method: 'POST',
        body: user,
        headers: {
            'Content-Type': 'application/json'
        }
    }
    );
    if (!response.ok) {
        alert("user name or email not exists");
    }
    else {
        if (response.status == '204') {
            alert("user name or email not exists");
        }
        else {
            const data = await response.json();
            if (data) {
                sessionStorage.setItem("userInfo", JSON.stringify({ firstname: data.firstName, lastname: data.lastName, id: data.id }));
                window.location.href = "update.html";
            }
        }
    }
}


async function Regist() {
    const email = document.getElementById("registEmail").value;
    const password = document.getElementById("registPassword").value;
    const firstname = document.getElementById("firstName").value;
    const lastname = document.getElementById("lastName").value;
    const user = JSON.stringify({ password: password, email: email, firstName: firstname, lastName: lastname });
    console.log("hello");
    console.log(email);
    console.log(password);
    const response = await fetch(
        '/api/users/regist', {
        method: 'POST',
        body: user,
        headers: {
            'Content-Type': 'application/json'
        }
    }
    );
    if (!response.ok) {
        if (response.status == '400') {
            alert(`email already exists ${response.status}`);
        }
    }
    else {
        if (response.status == '201') {
            alert("user created");
        }
        else {
            alert("all fields are require");
        }
    }
}

async function getPasswordStrength(password) {
    console.log(password)
    const response = await fetch(
        '/api/passwords', {
        method: 'POST',
            body: JSON.stringify({ password: password }),
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
        }
    }
    //const data = await axios.post("/api/users/password?password=" + password); 
    );
    const data = await response.json();
    console.log(data);
    document.getElementById("passwordStrength").value=data ;
}



