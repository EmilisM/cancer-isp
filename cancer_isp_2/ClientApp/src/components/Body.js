import React from "react";
import Container from "react-bootstrap/Container";
import { Route } from "react-router-dom";
import Home from "./Home/Home";
import Profile from "./Profile/Profile";
import SignUp from "./Signup/Signup";
import Login from "./Login/Login";
import Search from "./Search/Search";
import SongList from "./Song/Song.List";
import Admin from "./Admin/Admin";
import SongCreate from "./Song/Song.Create";
import ProfileCreateList from "./Profile/Profile.Create.List";
import Artist from "./Artist/Artist";
import ArtistList from "./Artist/Artist.List";

function Body() {
    return (
        <Container fluid="true">
            <Route exact path="/" component={Home}/>
            <Route exact path="/profile" component={Profile}/>
            <Route exact path="/login" component={Login}/>
            <Route exact path="/signup" component={SignUp}/>
            <Route exact path="/song/list" component={SongList}/>
            <Route exact path="/search" component={Search}/>
            <Route exact path="/admin" component={Admin}/>
            <Route exact path="/artist/:artistId(list)" component={ArtistList} />
            <Route exact path="/artist/:artistId([0-9]+)" component={Artist} />
            <Route exact path="/song/create" component={SongCreate}/>
            <Route exact path="/profile/create/list" component={ProfileCreateList}/>
        </Container>
    );
}

export default Body;