import React from "react";
import { Card, Row, Col, Form, Button } from "react-bootstrap";
import PropTypes from "prop-types";

function ArtistCreationCard(props) {
    ArtistCreationCard.propTypes = {
        name: PropTypes.string,
        fullName: PropTypes.string,
        birthDate: PropTypes.string,
        description: PropTypes.string,
        originDate: PropTypes.string,
        onArtistSubmit: PropTypes.func,
        onInputChange: PropTypes.func
    };

    return (
        <Card>
            <Card.Header>
                Create a new artist
            </Card.Header>
            <Card.Body>
                <Form onSubmit={props.onArtistSubmit}>
                    <Form.Group>
                        <Form.Label>Artist</Form.Label>
                        <Form.Control type="text" placeholder="Artist" name="name" value={props.name} onChange={props.onInputChange}/>
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Artist full name</Form.Label>
                        <Form.Control type="text" placeholder="Artist full name" name="fullName" value={props.fullName} onChange={props.onInputChange} />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Birth date</Form.Label>
                        <Form.Control type="date" placeholder="Birth date" name="birthDate" value={props.birthDate} onChange={props.onInputChange} />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Description</Form.Label>
                        <Form.Control type="textarea" placeholder="Description" rows="3" name="description" value={props.description} onChange={props.onInputChange}/>
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Date of origin</Form.Label>
                        <Form.Control type="date" placeholder="Start of career" name="originDate" value={props.originDate} onChange={props.onInputChange}/>
                    </Form.Group>
                    <Form.Group>
                        <Button type="submit">Create</Button>
                    </Form.Group>
                </Form>
            </Card.Body>
        </Card>
    );
}

class Artist extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            name: "",
            fullName: "",
            //birthDate: "",
            description: ""
            //originDate: "",
        };

        this.onInputChange = this.onInputChange.bind(this);
        this.onArtistSubmit = this.onArtistSubmit.bind(this);
    }

    onInputChange(e) {
        this.setState({
            [e.target.name]: e.target.value
        });
    }

    onArtistSubmit(e) {
        e.preventDefault();

        fetch(`api/artist/create/new`,
            {
                method: "POST",
                body: JSON.stringify({
                    name: this.state.name,
                    fullName: this.state.fullName,
                    description: this.state.description
                }),
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                }
            });
    }

    render() {
        return (
            <Row>
                <Col>
                    <Row>
                        <Col>
                            <ArtistCreationCard
                                onArtistSubmit={this.onArtistSubmit}
                                onInputChange={this.onInputChange}
                            />
                        </Col>
                    </Row>

                </Col>
            </Row>
        );
    }

}

export default Artist;