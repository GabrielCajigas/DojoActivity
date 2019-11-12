// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


const loginBtn = document.getElementById('login');
const signupBtn = document.getElementById('signup');
const emailvali = document.getElementById('EV');
const passvali = document.getElementById('PV');
const logindiv = document.getElementById('logindiv');

loginBtn.addEventListener('click', (e) => {
    let parent = e.target.parentNode.parentNode;
    Array.from(e.target.parentNode.parentNode.classList).find((element) => {
        if (element !== "slide-up") {
            parent.classList.add('slide-up')
        } else {
            signupBtn.parentNode.classList.add('slide-up')
            parent.classList.remove('slide-up')
        }
    });
});

signupBtn.addEventListener('click', (e) => {
    let parent = e.target.parentNode;
    Array.from(e.target.parentNode.classList).find((element) => {
        if (element !== "slide-up") {
            parent.classList.add('slide-up')
        } else {
            loginBtn.parentNode.parentNode.classList.add('slide-up')
            parent.classList.remove('slide-up')
        }
    });
});

if (emailvali.classList.value === "field-validation-error" || passvali.classList.value === "field-validation-error") {
    // console.log(passvali.classList.value);
    // console.log(emailvali.classList.value);
    logindiv.classList.remove('slide-up');
    signupBtn.parentNode.classList.add('slide-up');
}