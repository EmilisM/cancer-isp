import React from "react";
import { Card, Row, Col, Form, Image, ListGroup, ListGroupItem, Alert } from "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import CreateNewSongCard from "./Song.CreateNewSong";

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
    SongCard.propTypes = {
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
            }
        };

        Song.propTypes = {
            songId: PropTypes.number,
            song: PropTypes.object,
            match: PropTypes.object
        };
    }

    componentDidMount() {
        fetch(`api/song/${this.state.songId}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        song: result,
                        error: result.error
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

                          </Col>
                      </Row>
                }
            </div>
        );
    }
}

export default Song;