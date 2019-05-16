import React from "react";
import { Card } from "react-bootstrap";
import { Link } from "react-router-dom";

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

export default CreateNewArtistCard;