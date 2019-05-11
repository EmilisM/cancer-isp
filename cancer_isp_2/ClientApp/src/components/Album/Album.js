import React from "react";
import { Card, Row, Col, Form, Image, ListGroup, ListGroupItem, Alert } from "react-bootstrap";
import PropTypes from "prop-types";
import { Link } from "react-router-dom";

function AlbumCard({ album }) {
    AlbumCard.propTypes = {
        album: PropTypes.object
    };

    return (
        <Card>
            <Card.Header>
                Album
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Album name</Form.Label>
                    <br/>
                    <Form.Label>{album.name}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Artist(s)</Form.Label>
                    <br/>
                    <Form.Label>{album.artists.map(artist => artist.artist.alias).join(", ")}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Release date</Form.Label>
                    <br />
                    <Form.Label>{album.releaseDate}</Form.Label>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function ImageCard() {
    return (
        <Card>
            <Card.Header>
                Image
            </Card.Header>
            <Card.Body>
                <Image src="https://proxy.duckduckgo.com/iu/?u=http%3A%2F%2Ffiles.ontario.ca%2Fenvironment-and-energy%2Fconservation-and-stewardship%2Fredoak-tree.jpg&f=1"/>
            </Card.Body>
        </Card>
    );
}

function AlbumSongCard(props) {
    AlbumSongCard.propTypes = {
        songs: PropTypes.array
    };

    return (
        <Card>
            <Card.Header>
                Songs
            </Card.Header>
            <ListGroup className="list-group-flush">
                {props.songs.map(song => (
                    <ListGroupItem key={song.id}>
                        <Link to={`/song/${song.id}`}>{song.name}</Link>
                    </ListGroupItem>
                ))}
            </ListGroup>
            <Card.Body>
                <Card.Link href="#">Next</Card.Link>
                <Card.Link href="#">Previous</Card.Link>
            </Card.Body>
        </Card>
    );
}

class Album extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            albumId: this.props.match.params.albumId,
            error: null,
            album: {
                artists: [],
                songs: []
            }
        };

        Album.propTypes = {
            albumId: PropTypes.number,
            album: PropTypes.object,
            match: PropTypes.object
        };
    }

    componentDidMount() {
        fetch(`api/album/${this.state.albumId}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        album: result,
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
                                      <AlbumCard {...this.state}/>
                                  </Col>
                              </Row>

                          </Col>
                          <Col>

                              <Row>
                                  <Col>
                                      <ImageCard/>
                                  </Col>
                              </Row>

                              <Row>
                                  <Col>
                                      <AlbumSongCard songs={this.state.album.songs}/>
                                  </Col>
                              </Row>

                          </Col>
                      </Row>
                }
            </div>
        );
    }
}

export default Album;