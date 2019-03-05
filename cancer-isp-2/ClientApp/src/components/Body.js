import React from "react";
import Container from "react-bootstrap/Container";
import { Route } from "react-router-dom";
import Home from "./Home";
import Profile from "./Profile";
import SignUp from "./Signup";
import Login from "./Login";

function Body() {
    return (
        <Container fluid="true">
            <Route exact path="/" component={Home} />
            <Route exact path="/profile" component={Profile} />
            <Route exact path="/login" component={Login} />
            <Route exact path="/signup" component={SignUp} />
        </Container>
    );
}

export default Body;