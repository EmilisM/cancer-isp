import React from "react";
import { Card, Row, Col, Form, Image, ListGroup, ListGroupItem, Alert, Popover, OverlayTrigger, Button } from
    "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import CreateNewSongCard from "./Song.CreateNewSong";
import YouTube from "react-youtube";
import { FaPlus } from "react-icons/fa";

function SongCard({ song }) {
    SongCard.propTypes = {
        song: PropTypes.object
    };

    return (
        <Card>
            <Card.Header>
                Song
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Artist(s)</Form.Label>
                    <br/>
                    <Form.Label>{song.artists.map(artist => artist.artist.alias).join(", ")}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Song name</Form.Label>
                    <br/>
                    <Form.Label>{song.name}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Release date</Form.Label>
                    <br/>
                    <Form.Label>{song.releaseDate}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Genres</Form.Label>
                    <br/>
                    <Form.Label>{song.genres.map(genre => genre.genre.name).join(", ")}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Album</Form.Label>
                    <br/>
                    <Form.Label>
                        <Link to={`/album/${song.album.id}`}>{song.album.name}</Link>
                    </Form.Label>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function ImageCard({ image }) {
    ImageCard.propTypes = {
        image: PropTypes.object
    };

    return (
        <Card>
            <Card.Header>
                Image
            </Card.Header>
            <Card.Body>
                <Image src={image.url}/>
            </Card.Body>
        </Card>
    );
}

function SongPlaybackCard(props) {
    SongPlaybackCard.propTypes = {
        videoId: PropTypes.string,
        playlists: PropTypes.array,
        onClick: PropTypes.func,
        onSubmit: PropTypes.func,
        onChange: PropTypes.func
    };

    const opts = {
        height: "320",
        width: "640"
    };

    const popover = (
        <Popover id="popover-basic" title="Add song to playlist">
            <ListGroup variant="flush">
                {props.playlists.map(playlist =>
                    <ListGroup.Item key={playlist.id} style={{ cursor: "pointer" }} onClick={(e) => props.onClick(e,
                        playlist.id)}>
                        {playlist.name} <FaPlus/>
                    </ListGroup.Item>)}
                <ListGroup.Item>
                    <Form onSubmit={props.onSubmit}>
                        <Form.Group>
                            <Form.Label>Or create a new one</Form.Label>
                            <Form.Label>Playlist name</Form.Label>
                            <Form.Control placeholder="Name" onChange={props.onChange}/>
                        </Form.Group>
                        <Form.Group>
                            <Button type="submit">Create playlist</Button>
                        </Form.Group>
                    </Form>
                </ListGroup.Item>
            </ListGroup>
        </Popover>
    );

    return (
        <Card>
            <Card.Header>
                Song playback
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <YouTube videoId={props.videoId} opts={opts}/>
                </Form.Group>
                <Form.Group>
                    <OverlayTrigger trigger="click" placement="left" overlay={popover}>
                        <Button>Add song to playlist</Button>
                    </OverlayTrigger>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function SongRatingsCard(props) {
    SongRatingsCard.propTypes = {
        ratings: PropTypes.array
    };

    return (
        <Card>
            <Card.Header>
                Ratings
            </Card.Header>
            <ListGroup className="list-group-flush">
                {props.ratings.map(rating => (
                    <ListGroupItem key={rating.id}>
                        {rating.comment} - {rating.points} by {rating.user.username}
                    </ListGroupItem>
                ))}
            </ListGroup>

            <Card.Body>
                <Card.Link href="#">Next</Card.Link>
                <Card.Link href="#">Previous</Card.Link>
                <Card.Link href="#">Create new rating</Card.Link>
            </Card.Body>
        </Card>
    );
}

class Song extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            songId: this.props.match.params.songId,
            error: null,
            song: {
                ratings: [],
                artists: [],
                genres: [],
                album: {},
                image: {}
            },
            playlists: [],
            playlistName: null
        };

        Song.propTypes = {
            songId: PropTypes.number,
            song: PropTypes.object,
            match: PropTypes.object
        };

        this.onPlaylistClick = this.onPlaylistClick.bind(this);
        this.onPlaylistCreate = this.onPlaylistCreate.bind(this);
        this.onPlaylistNameChange = this.onPlaylistNameChange.bind(this);
    }

    onPlaylistNameChange(e) {
        e.preventDefault();

        this.setState({
            playlistName: e.target.value
        });
    }

    onPlaylistCreate(e) {
        e.preventDefault();

        fetch(`api/user/playlist/new/${this.state.playlistName}`, { method: "POST" })
            .then(() => {
                fetch(`api/user/playlists`)
                    .then(res => res.json())
                    .then(
                        (playlists) => {
                            this.setState({
                                playlists: playlists
                            });
                        });
            });
    }

    onPlaylistClick(e, data) {
        fetch(`api/user/playlist/${data}/add/${this.state.songId}`, { method: "POST" });
    }

    componentDidMount() {
        fetch(`api/song/${this.state.songId}`)
            .then(res => res.json())
            .then(
                (song) => {
                    fetch(`api/user/playlists`)
                        .then(res => res.json())
                        .then(
                            (playlists) => {
                                this.setState({
                                    playlists: playlists,
                                    song: song,
                                    error: song.error
                                });
                            });
                },
                (error) => {
                    this.setState({
                        error: error
                    });
                }
            );
    }

    render() {
        return (
            <div>
                {this.state.error != null
                    ? <Row>
                          <Col>
                              <Alert variant="danger">{this.state.error}</Alert>
                          </Col>
                      </Row>
                    : <Row>
                          <Col>

                              <Row>
                                  <Col>
                                      <SongCard {...this.state}/>
                                  </Col>
                              </Row>

                              <Row>
                                  <Col>
                                      <CreateNewSongCard/>
                                  </Col>
                              </Row>

                          </Col>
                          <Col>

                              <Row>
                                  <Col>
                                      <ImageCard image={this.state.song.image}/>
                                  </Col>
                              </Row>

                              <Row>
                                  <Col>
                                      <SongRatingsCard ratings={this.state.song.ratings}/>
                                  </Col>
                              </Row>

                              <Row>
                                  <Col>
                                      { this.state.song.youtubeVideoId !== null
                                          ? <SongPlaybackCard videoId={this.state.song.youtubeVideoId} playlists={this
                                              .state.playlists} onClick={this.onPlaylistClick} onChange={this
                                                  .onPlaylistNameChange} onSubmit={this.onPlaylistCreate}/>
                                          : <div></div> }
                                  </Col>
                              </Row>

                          </Col>
                      </Row>
                }
            </div>
        );
    }
}

export default Song;