import React from "react";
import Container from "react-bootstrap/Container";
import { Route } from "react-router-dom";
import Home from "./Home/Home";
import Profile from "./Profile/Profile";
import SignUp from "./Signup/Signup";
import Login from "./Login/Login";
import Song from "./Song/Song";
import Search from "./Search/Search";
import Artist from "./Artist/Artist";
import Admin from "./Admin/Admin";
import ArtistCreate from "./Artist/Artist.Create";
import SongCreate from "./Song/Song.Create";

function Body() {
    return (
        <Container fluid="true">
            <Route exact path="/" component={Home}/>
            <Route exact path="/profile" component={Profile}/>
            <Route exact path="/login" component={Login}/>
            <Route exact path="/signup" component={SignUp}/>
            <Route exact path="/song" component={Song}/>
            <Route exact path="/artist" component={Artist}/>
            <Route exact path="/search" component={Search}/>
            <Route exact path="/admin" component={Admin}/>
            <Route exact path="/artist/create" component={ArtistCreate}/>
            <Route exact path="/song/create" component={SongCreate}/>
        </Container>
    );
}

export default Body;