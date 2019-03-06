import React from "react";
import Container from "react-bootstrap/Container";
import { Route } from "react-router-dom";
import Home from "./Home";
import Profile from "./Profile";
import SignUp from "./Signup";
import Login from "./Login";
import Song from "./Song";
import Search from "./Search";
import Artist from "./Artist";
import Admin from "./Admin";
import ArtistCreate from "./Artist.Create";
import SongCreate from "./Song.Create";

function Body() {
    return (
        <Container fluid="true">
            <Route exact path="/" component={Home} />
            <Route exact path="/profile" component={Profile} />
            <Route exact path="/login" component={Login} />
            <Route exact path="/signup" component={SignUp} />
            <Route exact path="/song" component={Song} />
            <Route exact path="/artist" component={Artist} />
            <Route exact path="/search" component={Search} />
            <Route exact path="/admin" component={Admin} />
            <Route exact path="/artist/create" component={ArtistCreate} />
            <Route exact path="/song/create" component={SongCreate} />
        </Container>
    );
}

export default Body;