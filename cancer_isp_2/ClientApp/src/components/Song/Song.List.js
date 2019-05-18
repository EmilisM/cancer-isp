import React from "react";
import { Card, Row, Col, ListGroup, ListGroupItem } from "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";
import CreateNewSongCard from "./Song.CreateNewSong";

function NewSongCard({ songs }) {
    NewSongCard.propTypes = {
        songs: PropTypes.array
    };

    return (
        <Card>
            <Card.Header>
                New songs
            </Card.Header>
            <ListGroup className="list-group-flush">
                {songs.map(song => (
                    <ListGroupItem key={song.id}>
                        <Link to={`/song/${song.id}`}>{song.artists.map(artist => artist.artist.name).join(", ")} - {
                            song.name}</Link>
                    </ListGroupItem>
                ))}
            </ListGroup>
        </Card>
    );
}

class SongList extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            songs: []
        };
    }

    componentDidMount() {
        fetch("api/song/new")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        songs: result
                    });
                });
    }

    render() {
        return (
            <Row>
                <Col>

                    <Row>
                        <Col>
                            <NewSongCard {...this.state}/>
                        </Col>
                    </Row>

                    <Row>
                        <Col>
                            <CreateNewSongCard/>
                        </Col>
                    </Row>

                </Col>
            </Row>
        );
    }
}

export default SongList;