import React from "react";
import { Card, Row, Col, Form, Button } from "react-bootstrap";

function ArtistCreationCard() {
    return (
        <Card>
            <Card.Header>
                Create a new artist
            </Card.Header>
            <Card.Body>
                <Form>
                    <Form.Group>
                        <Form.Label>Artist</Form.Label>
                        <Form.Control type="text" placeholder="Artist"/>
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Artist full name</Form.Label>
                        <Form.Control type="text" placeholder="Artist full name"/>
                    </Form.Group>
                    <Form.Group>
                        <Button variant="primary" type="Repeat password">
                            Create
                        </Button>
                    </Form.Group>
                </Form>
            </Card.Body>
        </Card>
    );
}

function ArtistCreate() {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <ArtistCreationCard/>
                    </Col>
                </Row>

            </Col>
        </Row>
    );
}

export default ArtistCreate;