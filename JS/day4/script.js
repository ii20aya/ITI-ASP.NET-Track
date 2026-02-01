//2
var buttons = document.querySelectorAll(".width");
var inputt = document.getElementById("Answer");

buttons.forEach(function (btn) {
    btn.addEventListener("click", function () {

        if (btn.value == '='){

            var parts = inputt.value.split(/(\+|\-|\*|\/)/);

            
            if(parts.length < 3){
                alert("يرجى إدخال عملية كاملة");
                return;e`   X '/=[- ]`
            }

            var num1 = parseFloat(parts[0]);
            var operator = parts[1];
            var num2 = parseFloat(parts[2]);

            //  NaN
            if(isNaN(num1) || isNaN(num2)){
                alert("يرجى إدخال أرقام صحيحة");
                inputt.value = "";
                return;
            }

            //  undefined
            if(!operator){
                alert("يرجى إدخال عملية (+ - * /)");
                return;
            }

            var result;
            if(operator === "+") result = num1 + num2;
            else if(operator === "-") result = num1 - num2;
            else if(operator === "*") result = num1 * num2;
            else if(operator === "/") result = num1 / num2;

            inputt.value = result;

        }
        else if(btn.value == 'C'){
            inputt.value = "";

        } else {
            inputt.value += btn.value;
        }
    });
});

//====================================================

//2


var images = [
    "./images/1.jpg",
   "./images/2.jpg",
    "./images/3.jpg",
     "./images/4.jpg",
      "./images/5.jpg",
       "./images/6.jpg"
];

var index = 0;
var gallery = document.getElementById("gallery");
var intervalId;

document.getElementById("next").addEventListener("click", function () {
    if (index < images.length -1 ) {
        index++;
        gallery.src = images[index];
    }
});


document.getElementById("prev").addEventListener("click", function () {
    if (index > 0) {
        index--;
        gallery.src = images[index];
    }
});


document.getElementById("play").addEventListener("click", function () {

    intervalId = setInterval(function () {

        index++;

        if (index === images.length) {
            index = 0;
        }

        gallery.src = images[index];

    }, 2000);

});


document.getElementById("stop").addEventListener("click", function () {
    clearInterval(intervalId);
});


//====================================================

//3

var numinput = document.getElementById("numinput");

numinput.addEventListener('input',function(){
    this.value= this.value.replace(/[^0-9]/g,"")
})


//====================================================

//4




var nameInput = document.getElementById("name");
var ageInput = document.getElementById("age");
var emailInput = document.getElementById("email");
var addBtn = document.getElementById("add");
var tableBody = document.getElementById("tableBody");

addBtn.addEventListener("click", function () {
    var name = nameInput.value.trim();
    var age = ageInput.value.trim();
    var email = emailInput.value.trim();

    // 1. Validation for empty fields
    if (name === "" || age === "" || email === "") {
        alert("All fields are required!");
        return;
    }

    // 2. Name validation (Letters only)
    if (!/^[a-zA-Z\s]+$/.test(name)) {
        alert("Name must contain letters only!");
        return;
    }

    // 3. Age validation (Positive numbers)
    if (isNaN(age) || age <= 0) {
        alert("Please enter a valid positive age!");
        return;
    }

   
    var emailPattern = /^[a-zA-Z0-9._-]+@(gmail|yahoo)\.com$/;
    if (!emailPattern.test(email)) {
        alert("Invalid email! Use gmail.com or yahoo.com");
        return;
    }

  
    var tr = document.createElement("tr");

    tr.innerHTML = `
        <td>${name}</td>
        <td>${age}</td>
        <td>${email}</td>
    `;

    tableBody.appendChild(tr);

    
    nameInput.value = "";
    ageInput.value = "";
    emailInput.value = "";
});

