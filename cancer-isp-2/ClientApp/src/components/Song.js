import React from "react";
import { Card, Row, Col, Form, Image, ListGroup, ListGroupItem } from "react-bootstrap";
import { Link } from "react-router-dom";

function SongCard() {
    return (
        <Card>
            <Card.Header>
                Song
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Artist(s)</Form.Label>
                    <br/>
                    <Form.Label>Artist(s)</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Song name</Form.Label>
                    <br/>
                    <Form.Label>Song name</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Creation date</Form.Label>
                    <br/>
                    <Form.Label>Creation date</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Record label</Form.Label>
                    <br/>
                    <Form.Label>Record label</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Genres</Form.Label>
                    <br/>
                    <Form.Label>Genres</Form.Label>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Work type</Form.Label>
                    <br/>
                    <Form.Label>Work type</Form.Label>
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

function SongRatings() {
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

function CreateNewSongCard() {
    return (
        <Card>
            <Card.Header>
                Want to create a new song ?
            </Card.Header>
            <Card.Body>
                <div className="form-group">
                    <label>Use this link</label>
                </div>
                <div className="form-group">
                    <Link to="/song/create">Create new song</Link>
                </div>
            </Card.Body>
        </Card>
    );
}

function Song() {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <SongCard/>
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <CreateNewSongCard />
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
                        <SongRatings/>
                    </Col>
                </Row>

            </Col>
        </Row>
    );
}

export default Song;