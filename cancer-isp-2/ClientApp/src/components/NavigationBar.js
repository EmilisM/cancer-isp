import React from "react";
import { Navbar, Nav } from "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import { connect } from "react-redux";

function mapStateToProps(state) {
    return {
        loggedIn: state.loggedIn
    };
}

function mapDispatchToProps(dispatch) {
    return {
        onLogOut: () => {
            dispatch({ type: "LOGOUT_SUCCESS" });
        }
    };
}

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

function NavigationBar(props) {
    NavigationBar.propTypes = {
        loggedIn: PropTypes.bool,
        onLogOut: PropTypes.func
    }

    return (
        <div>
            <Navbar bg="dark" variant="dark">
                <Link className="navbar-brand" to="/">
                    Home
                </Link>

                {props.loggedIn
                    ? <Nav className="mr-auto">
                          <NavLink name="Profile" path="/profile"/>
                          <a className="nav-link" onClick={props.onLogOut}>Sign Out</a>
                      </Nav>
                    : <Nav className="mr-auto">
                        <NavLink name="Log In" path="/login" />
                        <NavLink name="Sign Up" path="/signup" />
                      </Nav>
                }
            </Navbar>
        </div>
    );
}

export default connect(mapStateToProps, mapDispatchToProps)(NavigationBar);