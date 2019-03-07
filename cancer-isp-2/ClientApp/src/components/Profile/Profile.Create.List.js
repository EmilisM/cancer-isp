import React from "react";
import "./Profile.css";
import { Card, Row, Col, Form, ListGroup, ListGroupItem, Button } from "react-bootstrap";

function CreateListCard() {
    return (
        <Card>
            <Card.Header>
                Create a list
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>List name</Form.Label>
                    <Form.Control type="text" placeholder="List name"/>
                </Form.Group>
                <Form.Group>
                    <Button variant="primary" type="submit">
                        Create
                    </Button>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function SelectedSongListCard() {
    return (
        <Card>
            <Card.Header>
                Selected songs
            </Card.Header>
            <ListGroup className="list-group-flush">
                <ListGroupItem>Cras justo odio</ListGroupItem>
                <ListGroupItem>Dapibus ac facilisis in</ListGroupItem>
                <ListGroupItem>Vestibulum at eros</ListGroupItem>
            </ListGroup>
        </Card>
    );
}

function SongListCard() {
    return (
        <Card>
            <Card.Header>
                Available song list
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Search for songs</Form.Label>
                    <Form.Control type="text" placeholder="Song name" />
                </Form.Group>
            </Card.Body>
            <ListGroup className="list-group-flush">
                <ListGroupItem>Cras justo odio</ListGroupItem>
                <ListGroupItem>Dapibus ac facilisis in</ListGroupItem>
                <ListGroupItem>Vestibulum at eros</ListGroupItem>
            </ListGroup>
        </Card>
    );
}

function ProfileCreateList() {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <CreateListCard/>
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <SelectedSongListCard />
                    </Col>
                </Row>

            </Col>
            <Col>

                <Row>
                    <Col>
                        <SongListCard/>
                    </Col>
                </Row>

            </Col>
        </Row>
    );
}

export default ProfileCreateList;