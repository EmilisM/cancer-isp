import React from "react";
import { Card, Row, Col, Form, ListGroup, ListGroupItem, Image } from "react-bootstrap";
import { Link } from "react-router-dom";

function ArtistCard() {
    return (
        <Card>
            <Card.Header>
                Artist
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Alias</Form.Label>
                    <br/>
                    <Form.Label>Alias</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Full name</Form.Label>
                    <br/>
                    <Form.Label>Full name</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Birthdate</Form.Label>
                    <br/>
                    <Form.Label>Birthdate</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Description</Form.Label>
                    <br/>
                    <Form.Label>Description</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Origin date</Form.Label>
                    <br/>
                    <Form.Label>yyyy-MM-dd</Form.Label>
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
                <Image src="https://proxy.duckduckgo.com/iu/?u=http%3A%2F%2Ffiles.ontario.ca%2Fenvironment-and-energy%2Fconservation-and-stewardship%2Fredoak-tree.jpg&f=1" />
            </Card.Body>
        </Card>
    );
}

function ArtistRatingCard() {
    return (
        <Card>
            <Card.Header>
                Ratings
            </Card.Header>
            <ListGroup className="list-group-flush">
                <ListGroupItem>Cras justo odio</ListGroupItem>
                <ListGroupItem>Dapibus ac facilisis in</ListGroupItem>
                <ListGroupItem>Vestibulum at eros</ListGroupItem>
            </ListGroup>
            <Card.Body>
                <Card.Link href="#">Next</Card.Link>
                <Card.Link href="#">Previous</Card.Link>
            </Card.Body>
        </Card>
    );
}

function ArtistSongsCard() {
    return (
        <Card>
            <Card.Header>
                Songs
            </Card.Header>
            <ListGroup className="list-group-flush">
                <ListGroupItem>Cras justo odio</ListGroupItem>
                <ListGroupItem>Dapibus ac facilisis in</ListGroupItem>
                <ListGroupItem>Vestibulum at eros</ListGroupItem>
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

function Artist() {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <ArtistCard/>
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <CreateNewArtistCard />
                    </Col>
                </Row>

            </Col>
            <Col>

                <Row>
                    <Col>
                        <ArtistImageCard />
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <ArtistRatingCard/>
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <ArtistSongsCard />
                    </Col>
                </Row>

            </Col>
        </Row>
    );
}

export default Artist;