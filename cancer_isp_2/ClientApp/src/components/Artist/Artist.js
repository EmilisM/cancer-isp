import React from "react";
import { Card, Row, Col, Form, ListGroup, ListGroupItem, Image, Alert } from "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";

function ArtistCard({ artist }) {
    ArtistCard.propTypes = {
        artist: PropTypes.object
    };

    return (
        <Card>
            <Card.Header>
                Artist
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Alias</Form.Label>
                    <br/>
                    <Form.Label>{artist.alias}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Full name</Form.Label>
                    <br/>
                    <Form.Label>{artist.fullName}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Birthdate</Form.Label>
                    <br/>
                    <Form.Label>{artist.birthdate}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Description</Form.Label>
                    <br/>
                    <Form.Label>{artist.description}</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Origin date</Form.Label>
                    <br/>
                    {artist.originDate != null
                        ? <Form.Label>{artist.originDate}</Form.Label>
                        : <div></div>}
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function ArtistImageCard() {
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

function ArtistAlbumsCard(props) {
    ArtistAlbumsCard.propTypes = {
        albums: PropTypes.array
    };

    return (
        <Card>
            <Card.Header>
                Albums
            </Card.Header>
            <ListGroup className="list-group-flush">
                {props.albums.map(album => (
                    <ListGroupItem key={album.album.id}>
                        {album.album.name}
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

function ArtistSongsCard(props) {
    ArtistSongsCard.propTypes = {
        songs: PropTypes.array
    };

    return (
        <Card>
            <Card.Header>
                Songs
            </Card.Header>
            <ListGroup className="list-group-flush">
                {props.songs.map(song => (
                    <ListGroupItem key={song.song.id}>
                        {song.song.name}
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

function CreateNewArtistCard() {
    return (
        <Card>
            <Card.Header>
                Want to create a new artist ?
            </Card.Header>
            <Card.Body>
                <div className="form-group">
                    <label>Use this link</label>
                </div>
                <div className="form-group">
                    <Link to="/artist/create">Create new artist</Link>
                </div>
            </Card.Body>
        </Card>
    );
}

class Artist extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            artistId: this.props.match.params.artistId,
            error: null,
            artist: { albums: [], songs: [] }
        };

        Artist.propTypes = {
            artistId: PropTypes.number,
            artist: PropTypes.object,
            match: PropTypes.object
        };
    }

    componentDidMount() {
        fetch(`api/artist/${this.state.artistId}`)
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        artist: result,
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
                { this.state.error != null
                    ? <Row>
                          <Col>
                              <Alert variant="danger">{this.state.error}</Alert>
                          </Col>
                      </Row>
                    : <Row>
                          <Col>

                              <Row>
                                  <Col>
                                      <ArtistCard {...this.state}/>
                                  </Col>
                              </Row>

                              <Row>
                                  <Col>
                                      <CreateNewArtistCard/>
                                  </Col>
                              </Row>

                          </Col>
                          <Col>

                              <Row>
                                  <Col>
                                      <ArtistImageCard/>
                                  </Col>
                              </Row>

                              <Row>
                                  <Col>
                                    <ArtistAlbumsCard albums={this.state.artist.albums}/>
                                  </Col>
                              </Row>

                              <Row>
                                  <Col>
                                    <ArtistSongsCard songs={this.state.artist.songs}/>
                                  </Col>
                              </Row>

                          </Col>
                      </Row>
                }
            </div>
        );
    }
}

export default Artist;