import React from "react";
import { Card, Row, Col, Form, Button } from "react-bootstrap";
import PropTypes from "prop-types";

function SongCreationCard(props) {
    SongCreationCard.propTypes = {
        name: PropTypes.string,
        artistName: PropTypes.string,
        releaseDate: PropTypes.string,
        description: PropTypes.string,
        length: PropTypes.string,
        onSongSubmit: PropTypes.func,
        onInputChange: PropTypes.func
    };

    return (
        <Card>
            <Card.Header>
                Create a new song
            </Card.Header>
            <Card.Body>
                <Form onSubmit={props.onSongSubmit}>
                    <Form.Group>
                        <Form.Label>Song name</Form.Label>
                        <Form.Control type="text" placeholder="Song name" name="name" value={props.songName} onChange={props.onInputChange} />
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Artist full name</Form.Label>
                        <Form.Control type="text" placeholder="Artist full name" name="artistName" value={props.artistName} onChange={props.onInputChange}/>
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Creation date</Form.Label>
                        <Form.Control type="date" placeholder="Creation date" name="releaseDate" value={props.creationDate} onChange={props.onInputChange}/>
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Description</Form.Label>
                        <Form.Control type="textarea" rows="3" placeholder="Description" name="description" value={props.description} onChange={props.onInputChange}/>
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Length in Seconds</Form.Label>
                        <Form.Control
                            type='number'
                            placeholder="Length in Seconds" name="length" value={props.length} onChange={props.onInputChange}
                        />
                    </Form.Group>
                    <Form.Group>
                        <Button type="submit">Create</Button>
                    </Form.Group>
                </Form>
            </Card.Body>
        </Card>
    );
}

class Song extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            //songId: this.props.match.params.songId,
            error: null,
            name: "",
            releaseDate: "",
            description: "",
            length: ""
        };

        this.onInputChange = this.onInputChange.bind(this);
        this.onSongSubmit = this.onSongSubmit.bind(this);
    }

    onInputChange(e) {
        this.setState({
            [e.target.name]: e.target.value
        });
    }

    onSongSubmit(e) {
        e.preventDefault();
        fetch(`api/song/create`,
            {
                method: "POST",
                body: JSON.stringify({
                    Name: this.state.name,
                    ReleaseDate: this.state.releaseDate,
                    Description: this.state.description,
                    LengthInSeconds: this.state.length
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
                            <SongCreationCard
                                name={this.state.name}
                                releaseDate={this.state.releaseDate}
                                description={this.state.description}
                                length={this.state.length}
                                onSubmit={this.onSongSubmit}
                                onChange={this.onInputChange}
                            />
                        </Col>
                    </Row>

                </Col>
            </Row>
        );
    }

}

export default Song;