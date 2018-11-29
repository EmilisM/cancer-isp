import "../styles/style.css";

import $ from "jquery";

import "popper.js";
import "bootstrap";

$("#submitEditProfile").on("click",
    function () {
        $("#profileEditForm").submit();
    });

$("#editProfile").on("click",
    function () {
        $("#submitEditProfile").attr("hidden", false);
        $("#editProfile").attr("hidden", true);

        const firstNameField = $("[name='FirstName']");
        firstNameField.replaceWith(`<input name='FirstName' class='form-control' value='${firstNameField.text()}'>`);

        const lastNameField = $("[name='LastName']");
        lastNameField.replaceWith(`<input name='LastName' class='form-control' value='${lastNameField.text()}'>`);
    });