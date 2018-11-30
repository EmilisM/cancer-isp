import "../styles/style.css";

import $ from "jquery";

import "popper.js";
import "bootstrap";

$("#submitEditProfile").on("click",
    function() {
        $("#profileEditForm").submit();
    });

$("#editProfile").on("click",
    function() {
        $("#submitEditProfile").attr("hidden", false);
        $("#editProfile").attr("hidden", true);

        const firstNameField = $("[name='FirstName']");
        firstNameField.replaceWith(`<input name='FirstName' class='form-control' value='${firstNameField.text()}'>`);

        const lastNameField = $("[name='LastName']");
        lastNameField.replaceWith(`<input name='LastName' class='form-control' value='${lastNameField.text()}'>`);

        const descriptionField = $("[name='Description']");
        descriptionField.replaceWith(
            `<textarea name='Description' class='form-control'>${descriptionField.text()}</textarea>`);

        const phoneNumberField = $("[name='PhoneNumber']");
        phoneNumberField.replaceWith(
            `<input name='PhoneNumber' class='form-control' value='${phoneNumberField.text()}'>`);

        const birthdayField = $("[name='Birthdate']");
        birthdayField.replaceWith(
            `<input name='Birthdate' class='form-control' value='${birthdayField.text()}'>`);
    });