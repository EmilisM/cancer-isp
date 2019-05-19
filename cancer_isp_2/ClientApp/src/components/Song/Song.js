import React from "react";
import { Card, Row, Col, Form, Image, ListGroup, ListGroupItem, Alert, Popover, OverlayTrigger, Button } from
    "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import CreateNewSongCard from "./Song.CreateNewSong";
import YouTube from "react-youtube";
import { FaPlus } from "react-icons/fa";

function SongCard({ song, songDetails }) {
    SongCard.propTypes = {
        song: PropTypes.object,
        songDetails: PropTypes.object
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
                    <Form.Label>{song.artists.map(artist => artist.artist.name).join(", ")}</Form.Label>
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
                {song.album == null
                    ? <div></div>
                    : <Form.Group>
                          <Form.Label>Album</Form.Label>
                          <br/>
                          <Form.Label>
                              <Link to={`/album/${song.album.id}`}>{song.album.name}</Link>
                          </Form.Label>
                      </Form.Group>
                }
                {songDetails == null
                    ? <div></div>
                    : <Form.Group>
                          <Form.Label>Song emotion</Form.Label>
                          <br/>
                          <Form.Label style={{ fontSize: "32px" }}>
                              <SongEmotion valence={songDetails.valence}/>
                          </Form.Label>
                      </Form.Group>
                }
            </Card.Body>
        </Card>
    );
}



function SongEmotion(props) {
    SongEmotion.propTypes = {
        valence: PropTypes.number
    };

    if (props.valence >= 0.8) {
        return <div>😀</div>;
    } else if (props.valence >= 0.6 && props.valence < 0.8) {
        return <div>🙂</div>;
    } else if (props.valence >= 0.4 && props.valence < 0.6) {
        return <div>😐</div>;
    } else if (props.valence >= 0.2 && props.valence < 0.4) {
        return <div>😢</div>;
    } else if (props.valence < 0.2) {
        return <div>😭</div>;
    } else {
        return <div></div>;
    }
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
        ratings: PropTypes.array,
        rating: PropTypes.string,
        comment: PropTypes.string,
        onRatingSubmit: PropTypes.func,
        onInputChange: PropTypes.func
    };

    const popover = (
        <Popover id="popover-basic" title="Add rating/comment">
            <Form onSubmit={props.onRatingSubmit}>
                <Form.Group>
                    <Form.Label>Rating</Form.Label>
                    <Form.Control placeholder="1-10" value={props.rating} name="rating" onChange={props
                        .onInputChange}/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Comment</Form.Label>
                    <Form.Control placeholder="Song is good!" value={props.comment} name="comment" onChange={props
                        .onInputChange
}/>
                </Form.Group>
                <Form.Group>
                    <Button type="submit">Create review</Button>
                </Form.Group>
            </Form>
        </Popover>
    );

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
                <OverlayTrigger trigger="click" placement="right" overlay={popover}>
                    <Card.Link href="#" onClick={(e) => e.preventDefault()}>Create new rating</Card.Link>
                </OverlayTrigger>
            </Card.Body>
        </Card>
    );
}

function SongReportCard() {
    return (
        <Card>
            <Card.Header>
                Song reporting
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Reason</Form.Label>
                    <Form.Control type="text" placeholder="Reason" />
                </Form.Group>
                <Form.Group>
                    <Button variant="primary" type="submit">
                        Report
                    </Button>
                </Form.Group>
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
            songDetails: {},
            playlists: [],
            playlistName: null,
            comment: "",
            rating: ""

        };

        Song.propTypes = {
            songId: PropTypes.number,
            song: PropTypes.object,
            match: PropTypes.object
        };

        this.onPlaylistClick = this.onPlaylistClick.bind(this);
        this.onPlaylistCreate = this.onPlaylistCreate.bind(this);
        this.onPlaylistNameChange = this.onPlaylistNameChange.bind(this);
        this.onRatingSubmit = this.onRatingSubmit.bind(this);
        this.onRatingInputChange = this.onRatingInputChange.bind(this);
    }

    onRatingInputChange(e) {
        this.setState({
            [e.target.name]: e.target.value
        });
    }

    onRatingSubmit(e) {
        e.preventDefault();

        fetch(`api/song/${this.state.songId}/new/comment`,
            {
                method: "POST",
                body: JSON.stringify({ Rating: this.state.rating, Comment: this.state.comment }),
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                }
            });
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
                (result) => {
                    fetch(`api/user/playlists`)
                        .then(res => res.json())
                        .then(
                            (playlists) => {
                                this.setState({
                                    playlists: playlists,
                                    song: result.song,
                                    songDetails: result.songDetails,
                                    error: result.song.error
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
                            <Row>
                                <Col>
                                    <SongReportCard/>
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
                                      <SongRatingsCard ratings={this.state.song.ratings} rating={this.state.rating
                                          .rating}
                                                       comment={this.state.rating.comment} onRatingSubmit={this
                                                           .onRatingSubmit} onInputChange={this.onRatingInputChange}/>
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