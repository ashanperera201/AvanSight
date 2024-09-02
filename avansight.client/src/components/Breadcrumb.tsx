import React from 'react';
import { useLocation, Link } from 'react-router-dom';

const Breadcrumb: React.FC = () => {
    const location = useLocation();
    const pathnames = location.pathname.split('/').filter(x => x);

    return (
        <div className="breadcrumb" style={{ marginBottom: '20px' }}>
            <Link to="/">Home</Link>
            {pathnames.map((value, index) => {
                const to = `/${pathnames.slice(0, index + 1).join('/')}`;
                return (
                    <span key={to} style={{ margin: '0 5px' }}>
                        <span> &gt; </span>
                        <Link to={to}>{value}</Link>
                    </span>
                );
            })}
        </div>
    );
};

export default Breadcrumb;
