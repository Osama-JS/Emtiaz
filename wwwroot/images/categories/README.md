# Category Icons Directory

This directory contains uploaded icon images for categories.

## File Naming Convention
- Files are named with GUID format: `{guid}.{extension}`
- Supported formats: JPG, PNG, GIF, WebP, SVG
- Maximum file size: 5MB

## Usage
- Icons are uploaded through the Category management interface
- Files are automatically validated for size and type
- Old icons are automatically deleted when updated
- Icons are served directly from this directory via web requests

## Path Structure
- Web path: `/images/categories/{filename}`
- Physical path: `wwwroot/images/categories/{filename}`
