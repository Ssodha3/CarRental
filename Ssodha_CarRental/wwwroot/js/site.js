// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function submitForm() {
    var car = document.getElementById('car').value;
    var cusName = document.getElementById('cusName').value;
    var cNo = document.getElementById('cNo').value;
    var dateTime = document.getElementById('dateTime').value;

    // Create an object to hold the form data
    var formData = {
        car: car,
        cusName: cusName,
        cNo: cNo,
        dateTime: dateTime
    };

    // Send the form data to the server
    fetch('/ReservationForm', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(formData)
    }).then(response => {
        if (response.ok) {
            // Redirect to confirmation page
            window.location.href = '/ConfirmationMsg';
        } else {
            // Handle errors
            console.error('Error submitting form');
        }
    }).catch(error => {
        console.error('Error submitting form:', error);
    });
}