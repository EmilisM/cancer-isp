import React from "react";
import { Navbar, Nav } from "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";

const NavLink = (props) => {
    NavLink.propTypes = {
        path: PropTypes.any,
        name: PropTypes.any
    }

    return (
        <Link className="nav-link" to={props.path}>
            {props.name}
        </Link>
    );
};

function NavigationBar() {
    return (
        <div>
            <Navbar bg="dark" variant="dark">
                <Link className="navbar-brand" to="/">
                    Home
                </Link>
                <Nav className="mr-auto">
                    <NavLink name="Profile" path="/profile" />
                    <NavLink name="Log In" path="/login" />
                    <NavLink name="Sign Up" path="/signup" />
                </Nav>
            </Navbar>
        </div>
    );
}

export default NavigationBar;